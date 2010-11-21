// /************************************************************
// *  
// * Copyright (c) 2010 Dave Dolan. All Rights Reserved
// *  
// *  Author: Dave Dolan
// *   
// ************************************************************/
using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple3{
    public class AssignStatement : Statement{
        private readonly Expression _expr;
        private readonly Identifier _receiver;

        [Rule(@"<Statement> ::= Id ~'=' <Expression>")]
        public AssignStatement(Identifier receiver, Expression expr){
            _receiver = receiver;
            _expr = expr;
        }

        public override void Execute(Simple3ExecutionContext ctx){
            ctx[_receiver._idName] = _expr.GetValue(ctx);
        }
    }
}