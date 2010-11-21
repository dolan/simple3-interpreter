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
    [Terminal("&")]
    public class AndOperator : BinaryOperator{
        public override bool SkipConversion{
            get { return true; }
        }

        public override object Evaluate(object left, object right){
            return string.Concat(Convert.ToString(left), Convert.ToString(right));
        }
    }
}