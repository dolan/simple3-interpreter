// /************************************************************
// *  
// * Copyright (c) 2010 Dave Dolan. All Rights Reserved
// *  
// *  Author: Dave Dolan
// *   
// ************************************************************/
using System.Collections.Generic;
using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple3{
    public class StatementBlock : Statement{
        private readonly IEnumerable<Statement> _block;

        [Rule("<DelimitedStatement> ::= begin <Statements> end", ConstructorParameterMapping = new[] {1})]
        public StatementBlock(IEnumerable<Statement> block){
            _block = block;
        }

        public override void Execute(Simple3ExecutionContext ctx){
            foreach (var stmt in _block){
                stmt.Execute(ctx);
            }
        }
    }
}