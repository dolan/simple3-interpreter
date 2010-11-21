// /************************************************************
// *  
// * Copyright (c) 2010 Dave Dolan. All Rights Reserved
// *  
// *  Author: Dave Dolan
// *   
// ************************************************************/
using System;
using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple3{
    [Terminal("-")]
    public class MinusOperator : BinaryOperator{
        public override bool SkipConversion{
            get { return true; }
        }

        public override object Evaluate(object left, object right){
            return Convert.ToDouble(left) - Convert.ToDouble(right);
        }
    }
}