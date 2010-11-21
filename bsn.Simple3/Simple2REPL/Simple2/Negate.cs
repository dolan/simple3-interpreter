using System;
using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple2{
    public class Negate : Expression{
        private readonly Expression computable;

        [Rule("<Negate Exp>  ::= '-' <Value>", ConstructorParameterMapping = new[] {1})]
        public Negate(Expression computable){
            this.computable = computable;
        }

        public override object GetValue(SimpleExecutionContext ctx){
            return -(Convert.ToDecimal(computable.GetValue(ctx)));
        }
    }
}