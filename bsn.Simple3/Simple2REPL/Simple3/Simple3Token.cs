// /************************************************************
// *  
// * Copyright (c) 2010 Dave Dolan. All Rights Reserved
// *  
// *  Author: Dave Dolan
// *   
// ************************************************************/
using bsn.GoldParser.Semantic;
using SimpleREPL.Simple3;

[assembly: RuleTrim("<Value> ::= '(' <Expression> ')'", "<Expression>", SemanticTokenType = typeof (Simple3Token))]

namespace SimpleREPL.Simple3{
    [Terminal("(EOF)")]
    [Terminal("(Error)")]
    [Terminal("(Whitespace)")]
    //[Terminal("{")]
    //[Terminal("}")]
    [Terminal("(")]
    [Terminal(")")]
    [Terminal(",")]
    [Terminal(";")]
    [Terminal("=")]
    public class Simple3Token : SemanticToken{
    }
}