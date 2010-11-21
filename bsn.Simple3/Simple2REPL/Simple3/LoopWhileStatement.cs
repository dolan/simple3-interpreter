// /************************************************************
// *  
// * Copyright (c) 2010 Dave Dolan. All Rights Reserved
// *  
// *  Author: Dave Dolan
// *   
// ************************************************************/
using System;
using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple3{
    public class LoopWhileStatement : Statement{
        private readonly Expression _test;
        private readonly Sequence<Statement> _trueStatements;

        [Rule(@"<Statement> ::= ~loop <Statements> ~while <Expression>")]
        public LoopWhileStatement(Sequence<Statement> trueStatements, Expression test){
            _test = test;
            _trueStatements = trueStatements;
        }

        public override void Execute(Simple3ExecutionContext ctx){
            do{
                foreach (Statement stmt in _trueStatements){
                    stmt.Execute(ctx);
                }
            } while (Convert.ToBoolean(_test.GetValue(ctx)));
        }
    }
}