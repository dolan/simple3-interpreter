﻿using System;
using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple2{
    public class IfStatement : Statement{
        private readonly Sequence<Statement> _falseStatements;
        private readonly Expression _test;
        private readonly Sequence<Statement> _trueStatements;

        [Rule(@"<Statement> ::= if <Expression> then <Statements> end", ConstructorParameterMapping = new[] {1, 3})]
        public IfStatement(Expression _test, Sequence<Statement> trueStatements)
            : this(_test, trueStatements, null){
        }

        [Rule(@"<Statement> ::= if <Expression> then <Statements> else <Statements> end",
            ConstructorParameterMapping = new[] {1, 3, 5})]
        public IfStatement(Expression test, Sequence<Statement> trueStatements, Sequence<Statement> falseStatements){
            _test = test;
            _trueStatements = trueStatements;
            _falseStatements = falseStatements;
        }

        public override void Execute(SimpleExecutionContext ctx){
            if (Convert.ToBoolean(_test.GetValue(ctx))){
                foreach (Statement stmt in _trueStatements){
                    stmt.Execute(ctx);
                }
            }
            else{
                if (_falseStatements != null){
                    foreach (Statement stmt in _falseStatements){
                        stmt.Execute(ctx);
                    }
                }
            }
        }
    }
}