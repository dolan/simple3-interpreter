// /************************************************************
// *  
// * Copyright (c) 2010 Dave Dolan. All Rights Reserved
// *  
// *  Author: Dave Dolan
// *   
// ************************************************************/
using System.Diagnostics;
using System.IO;
using System.Text;
using bsn.GoldParser.Grammar;
using bsn.GoldParser.Parser;
using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple3{
    internal class REPLCator3: IRun{
        private readonly Stopwatch sw = new Stopwatch();

        private void StartTime(){
            if (TimerOn)
                sw.Start();
        }

        private void StopTime(string label, Simple3ExecutionContext ctx){
            if (TimerOn){
                sw.Stop();
                ctx.OutputStream.WriteLine("{0}: Elapsed: {1}ms", label, sw.ElapsedMilliseconds);
                sw.Reset();
            }
        }

        public bool TimerOn { get; set; }

        public void Run(){
            TimerOn = false;

            using (var ctx = new Simple3ExecutionContext()){
                Banner(ctx);

                StartTime();
                CompiledGrammar grammar = CompiledGrammar.Load(typeof (Simple3Token), "Simple3.cgt");
                var actions = new SemanticTypeActions<Simple3Token>(grammar);
                StopTime("Building Parser", ctx);

                for (string input = ReadABit(ctx); !string.IsNullOrEmpty(input); input = ReadABit(ctx)){
                    if (input.ToLower().Trim() == "timer"){
                        TimerOn = !TimerOn;
                        if (TimerOn)
                            ctx.OutputStream.WriteLine("Timer toggled to ON.");
                        else{
                            ctx.OutputStream.WriteLine("Timer toggled to OFF.");
                        }
                        continue;
                    }
                    else if (input.ToLower().Trim() == "exit"){
                        ctx.OutputStream.WriteLine("Exiting...");
                        return;
                    }

                    var processor = new SemanticProcessor<Simple3Token>(new StringReader(input), actions);

                    StartTime();
                    ParseMessage parseMessage = processor.ParseAll();
                    StopTime("Parse", ctx);

                    if (parseMessage == ParseMessage.Accept){
                        ctx.OutputStream.WriteLine("Ok.\n");

                        StartTime();
                        var stmts = processor.CurrentToken as Sequence<Statement>;
                        if (stmts != null){
                            foreach (Statement stmt in stmts){
                                stmt.Execute(ctx);
                            }
                        }
                        StopTime("Execution", ctx);
                    }
                    else{
                        IToken token = processor.CurrentToken;
                        ctx.OutputStream.WriteLine("At index: {0} [{1}]", token.Position.Index, parseMessage);
                        //Console.WriteLine(string.Format("{0} {1}", "^".PadLeft(token.Position.Index + 1), parseMessage));
                    }
                }
            }
        }

        private void Banner(Simple3ExecutionContext ctx){
            ctx.OutputStream.WriteLine("*** SIMPLE 3 REPL *** ");
            ctx.OutputStream.WriteLine(" by Dave Dolan on August 29, 2010.");
            ctx.OutputStream.WriteLine("\n -- Enter a blank line to 'go' or Ctrl+C to exit\n\n");
        }

        private string ReadABit(Simple3ExecutionContext ctx){
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