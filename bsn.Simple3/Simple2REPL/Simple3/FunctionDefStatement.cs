// /************************************************************
// *  
// * Copyright (c) 2010 Dave Dolan. All Rights Reserved
// *  
// *  Author: Dave Dolan
// *   
// ************************************************************/
using System.Collections.Generic;
using System.Linq;
using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple3{
    public class FunctionDefStatement : Statement{
        private readonly string _name;
        private readonly Sequence<Statement> _body;
        private readonly List<string> _paramNames;

        [Rule(@"<Statement> ::= function Id '(' <OptionalParamList> ')' begin <Statements> end",
            ConstructorParameterMapping = new[] {1, 3, 6})]
        public FunctionDefStatement(Identifier id, Optional<Sequence<Identifier>> paramList, Sequence<Statement> body){
            _name = id._idName;
            IEnumerable<Identifier> parameters = paramList.Value.ToArray() ?? new Identifier[0];
            _paramNames = new List<string>();
            foreach (var ident in parameters){
                _paramNames.Add(ident._idName.ToUpper());
            }
            _body = body;
        }


        public override void Execute(Simple3ExecutionContext ctx){
            var def = new FunctionDefinition
                      {
                          ParameterNames = _paramNames,
                          Body = _body.AsEnumerable()
                      };
            ctx.DefineFunction(_name, def);
        }
    }
}