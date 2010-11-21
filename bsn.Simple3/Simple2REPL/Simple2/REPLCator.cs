// /************************************************************
// *  
// * Copyright (c) 2010 Dave Dolan. All Rights Reserved
// *  
// *  Author: Dave Dolan
// *   
// ************************************************************/
using System.IO;
using System.Text;
using bsn.GoldParser.Grammar;
using bsn.GoldParser.Parser;
using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple2{
    internal class REPLCator: IRun{
        public void Run(){
            using (var ctx = new SimpleExecutionContext()){
                Banner(ctx);

                CompiledGrammar grammar = CompiledGrammar.Load(typeof (Simple2Token), "Simple2.cgt");
                var actions = new SemanticTypeActions<Simple2Token>(grammar);

                for (string input = ReadABit(ctx); !string.IsNullOrEmpty(input); input = ReadABit(ctx)){
                    var processor = new SemanticProcessor<Simple2Token>(new StringReader(input), actions);

                    ParseMessage parseMessage = processor.ParseAll();
                    if (parseMessage == ParseMessage.Accept){
                        ctx.OutputStream.WriteLine("Ok.\n");

                        var stmts = processor.CurrentToken as Sequence<Statement>;
                        if (stmts != null){
                            foreach (Statement stmt in stmts){
                                stmt.Execute(ctx);
                            }
                        }
                    }
                    else{
                        IToken token = processor.CurrentToken;
                        ctx.OutputStream.WriteLine("At index: {0} [{1}]", token.Position.Index, parseMessage);
                        //Console.WriteLine(string.Format("{0} {1}", "^".PadLeft(token.Position.Index + 1), parseMessage));
                    }
                }
            }
        }

        private void Banner(SimpleExecutionContext ctx){
            ctx.OutputStream.WriteLine("*** SIMPLE2 REPL *** ");
            ctx.OutputStream.WriteLine(" by Dave Dolan on August 25, 2010.");
            ctx.OutputStream.WriteLine("\n -- Enter a blank line to 'go' or Ctrl+C to exit\n\n");
        }

        private string ReadABit(SimpleExecutionContext ctx){
            ctx.OutputStream.Write("> ");

            string inputLine = null;

            var sb = new StringBuilder();

            while (string.Empty != inputLine){
                inputLine = ctx.InputStream.ReadLine();
                if (!string.IsNullOrEmpty(inputLine)){
                    sb.AppendLine(inputLine);
                }
            }

            return sb.ToString();
        }
    }
}