// /************************************************************
// *  
// * Copyright (c) 2010 Dave Dolan. All Rights Reserved
// *  
// *  Author: Dave Dolan
// *   
// ************************************************************/
namespace SimpleREPL.Simple3{
    public abstract class Statement : Simple3Token{
        public abstract void Execute(Simple3ExecutionContext ctx);
    }
}