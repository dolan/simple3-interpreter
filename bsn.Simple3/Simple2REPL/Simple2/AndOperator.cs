using System;
using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple2{
    [Terminal("&")]
    public class AndOperator : BinaryOperator{
        public override object Evaluate(object left, object right){
            return string.Concat(Convert.ToString(left), Convert.ToString(right));
        }
    }
}