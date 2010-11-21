using System;
using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple2{
    public class WhileStatement : Statement{
        private readonly Expression _test;
        private readonly Sequence<Statement> _trueStatements;

        [Rule(@"<Statement> ::= while <Expression> do <Statements> end", ConstructorParameterMapping = new[] {1, 3})]
        public WhileStatement(Expression test, Sequence<Statement> trueStatements){
            _test = test;
            _trueStatements = trueStatements;
        }

        public override void Execute(SimpleExecutionContext ctx){
            while (Convert.ToBoolean(_test.GetValue(ctx))){
                foreach (Statement stmt in _trueStatements){
                    stmt.Execute(ctx);
                }
            }
        }
    }
}