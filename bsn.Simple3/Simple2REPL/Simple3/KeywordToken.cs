// /************************************************************
// *  
// * Copyright (c) 2010 Dave Dolan. All Rights Reserved
// *  
// *  Author: Dave Dolan
// *   
// ************************************************************/
using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple3{
    [Terminal("print")]
    [Terminal("for")]
    [Terminal("function")]
    [Terminal("loop")]
    [Terminal("do")]
    [Terminal("else")]
    [Terminal("begin")]
    [Terminal("return")]
    [Terminal("end")]
    [Terminal("if")]
    [Terminal("read")]
    [Terminal("then")]
    [Terminal("while")]
    public class KeywordToken : Simple3Token{
    }
}