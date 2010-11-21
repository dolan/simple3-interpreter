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
    public class Negate : Expression{
        private readonly Expression computable;

        [Rule("<Negate Exp>  ::= '-' <Value>", ConstructorParameterMapping = new[] {1})]
        public Negate(Expression computable){
            this.computable = computable;
        }

        public override object GetValue(Simple3ExecutionContext ctx){
            return -(Convert.ToDouble(computable.GetValue(ctx)));
        }
    }
}