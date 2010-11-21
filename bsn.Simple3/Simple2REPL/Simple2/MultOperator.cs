﻿using System;
using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple2{
    [Terminal("*")]
    public class MultOperator : BinaryOperator{
        public override object Evaluate(object left, object right){
            return Convert.ToDecimal(left)*Convert.ToDecimal(right);
        }
    }
}