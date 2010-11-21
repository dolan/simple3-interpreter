using System;
using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple2{
    [Terminal("NumberLiteral")]
    public class NumberLiteral : Expression{
        private readonly decimal _value;

        public NumberLiteral(string value){
            _value = Convert.ToDecimal(value);
        }

        public override object GetValue(SimpleExecutionContext ctx){
            return _value;
        }
    }
}