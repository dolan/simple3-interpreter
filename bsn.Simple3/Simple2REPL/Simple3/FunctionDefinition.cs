// /************************************************************
// *  
// * Copyright (c) 2010 Dave Dolan. All Rights Reserved
// *  
// *  Author: Dave Dolan
// *   
// ************************************************************/
using System.Collections.Generic;

namespace SimpleREPL.Simple3{
    public class FunctionDefinition{
        public List<string> ParameterNames = new List<string>();
        public IEnumerable<Statement> Body;
    }
}