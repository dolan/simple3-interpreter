using System;
using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple2{
    [Terminal("<")]
    public class LTOperator : BinaryOperator{
        public override object Evaluate(object left, object right){
            return ((IComparable) left).CompareTo(right) < 0;
        }
    }
}