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
    public class WhileStatement : Statement{
        private readonly Expression _test;
        private readonly Sequence<Statement> _trueStatements;

        [Rule(@"<Statement> ::= while <Expression> do <Statements> end", ConstructorParameterMapping = new[] {1, 3})]
        public WhileStatement(Expression test, Sequence<Statement> trueStatements){
            _test = test;
            _trueStatements = trueStatements;
        }

        public override void Execute(Simple3ExecutionContext ctx){
            while (Convert.ToBoolean(_test.GetValue(ctx))){
                foreach (Statement stmt in _trueStatements){
                    stmt.Execute(ctx);
                }
            }
        }
    }
}