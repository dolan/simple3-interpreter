// /************************************************************
// *  
// * Copyright (c) 2010 Dave Dolan. All Rights Reserved
// *  
// *  Author: Dave Dolan
// *   
// ************************************************************/
using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple3{
    public class ReturnStatement : Statement{
        private readonly Expression _toReturn;

        [Rule(@"<Statement> ::= return <Expression>", ConstructorParameterMapping = new[] {1})]
        public ReturnStatement(Expression toReturn){
            _toReturn = toReturn;
        }


        public override void Execute(Simple3ExecutionContext ctx){
            ctx.ReturnValues.Push(_toReturn.GetValue(ctx));
        }
    }
}