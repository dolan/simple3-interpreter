// /************************************************************
// *  
// * Copyright (c) 2010 Dave Dolan. All Rights Reserved
// *  
// *  Author: Dave Dolan
// *   
// ************************************************************/
namespace SimpleREPL.Simple3{
    public abstract class BinaryOperator : Simple3Token{
        public virtual bool SkipConversion{
            get { return false; }
        }

        public abstract object Evaluate(object left, object right);
    }
}