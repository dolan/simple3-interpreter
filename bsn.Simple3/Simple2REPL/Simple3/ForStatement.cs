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
    public class ForStatement : Statement{
        private readonly Statement _initializer;
        private readonly Expression _test;
        private readonly Statement _step;
        private readonly Sequence<Statement> _body;

        [Rule(@"<Statement> ::= for '(' <Statement> ';' <Expression> ';' <Statement> ')' do <Statements> end",
            ConstructorParameterMapping = new[] {2, 4, 6, 9})]
        public ForStatement(Statement initializer, Expression test, Statement step, Sequence<Statement> body){
            _initializer = initializer;
            _test = test;
            _step = step;
            _body = body;
        }

        public override void Execute(Simple3ExecutionContext ctx){
            _initializer.Execute(ctx);
            while (Convert.ToBoolean(_test.GetValue(ctx))){
                foreach (var stmt in _body){
                    stmt.Execute(ctx);
                }
                _step.Execute(ctx);
            }
        }
    }
}