// /************************************************************
// *  
// * Copyright (c) 2010 Dave Dolan. All Rights Reserved
// *  
// *  Author: Dave Dolan
// *   
// ************************************************************/
using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple3{
    [Terminal("Id")]
    public class Identifier : Expression{
        internal readonly string _idName;

        public Identifier(string idName){
            _idName = idName;
        }

        public override object GetValue(Simple3ExecutionContext ctx){
            return ctx[_idName];
        }
    }
}