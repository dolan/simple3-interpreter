using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple2{
    public class AssignStatement : Statement{
        private readonly Expression _expr;
        private readonly Identifier _receiver;

        [Rule(@"<Statement> ::= assign Id '=' <Expression>", ConstructorParameterMapping = new[] {1, 3})]
        public AssignStatement(Identifier receiver, Expression expr){
            _receiver = receiver;
            _expr = expr;
        }

        public override void Execute(SimpleExecutionContext ctx){
            ctx[_receiver._idName] = _expr.GetValue(ctx);
        }
    }
}