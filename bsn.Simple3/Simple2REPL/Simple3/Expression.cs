// /************************************************************
// *  
// * Copyright (c) 2010 Dave Dolan. All Rights Reserved
// *  
// *  Author: Dave Dolan
// *   
// ************************************************************/
namespace SimpleREPL.Simple3{
    public abstract class Expression : Simple3Token{
        public abstract object GetValue(Simple3ExecutionContext ctx);
    }
}