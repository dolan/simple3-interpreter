// /************************************************************
// *  
// * Copyright (c) 2010 Dave Dolan. All Rights Reserved
// *  
// *  Author: Dave Dolan
// *   
// ************************************************************/
using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple3{
    public class DisplayStatement : Statement{
        private readonly Expression _expr;
        private readonly Identifier _identToRead;


        [Rule(@"<Statement> ::= print <Expression>", ConstructorParameterMapping = new[] {1})]
        public DisplayStatement(Expression expr)
            : this(expr, null){
        }

        [Rule(@"<Statement> ::= print <Expression> read Id", ConstructorParameterMapping = new[] {1, 3})]
        public DisplayStatement(Expression expr, Identifier identToRead){
            _expr = expr;
            _identToRead = identToRead;
        }


        public override void Execute(Simple3ExecutionContext ctx){
            object outputToDisplay = _expr.GetValue(ctx);

            if (_identToRead == null){
                ctx.OutputStream.WriteLine(outputToDisplay.ToString());
            }
            else{
                ctx.OutputStream.Write("{0} \n>", outputToDisplay);
                ctx[_identToRead._idName] = ctx.InputStream.ReadLine();
            }
        }
    }
}