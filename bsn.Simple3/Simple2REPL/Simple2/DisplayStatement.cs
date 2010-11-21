using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple2{
    public class DisplayStatement : Statement{
        private readonly Expression _expr;
        private readonly Identifier _identToRead;


        [Rule(@"<Statement> ::= display <Expression>", ConstructorParameterMapping = new[] {1})]
        public DisplayStatement(Expression expr)
            : this(expr, null){
        }

        [Rule(@"<Statement> ::= display <Expression> read Id", ConstructorParameterMapping = new[] {1, 3})]
        public DisplayStatement(Expression expr, Identifier identToRead){
            _expr = expr;
            _identToRead = identToRead;
        }


        public override void Execute(SimpleExecutionContext ctx){
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