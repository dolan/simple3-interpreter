// /************************************************************
// *  
// * Copyright (c) 2010 Dave Dolan. All Rights Reserved
// *  
// *  Author: Dave Dolan
// *   
// ************************************************************/
using System.Text.RegularExpressions;
using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple3{
    [Terminal("StringLiteral")]
    public class StringLiteral : Expression{
        private readonly string _value;

        public StringLiteral(string value){
            _value = Regex.Unescape(value.Substring(1, value.Length - 2));
        }


        public override object GetValue(Simple3ExecutionContext ctx){
            return _value;
        }
    }
}