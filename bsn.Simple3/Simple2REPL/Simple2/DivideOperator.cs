using System;
using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple2{
    [Terminal("/")]
    public class DivideOperator : BinaryOperator{
        public override object Evaluate(object left, object right){
            return Convert.ToDecimal(left)/Convert.ToDecimal(right);
        }
    }
}