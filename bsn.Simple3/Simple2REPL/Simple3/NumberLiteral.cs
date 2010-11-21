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
    [Terminal("NumberLiteral")]
    public class NumberLiteral : Expression{
        private readonly double _value;

        public NumberLiteral(string value){
            _value = Convert.ToDouble(value);
        }

        public override object GetValue(Simple3ExecutionContext ctx){
            return _value;
        }
    }
}