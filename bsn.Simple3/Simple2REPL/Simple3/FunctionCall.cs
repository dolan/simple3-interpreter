// /************************************************************
// *  
// * Copyright (c) 2010 Dave Dolan. All Rights Reserved
// *  
// *  Author: Dave Dolan
// *   
// ************************************************************/
using System.Linq;
using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple3{
    public class FunctionCall : Expression{
        private readonly Identifier _id;
        private readonly Expression[] _arguments;

        [Rule(@"<Value> ::= Id ~'(' <OptionalArgumentList> ~')'")]
        public FunctionCall(Identifier id, Optional<Sequence<Expression>> args){
            _id = id;
            _arguments = args.Value.ToArray() ?? new Expression[0];
        }


        public override object GetValue(Simple3ExecutionContext ctx){
            var def = ctx.GetFunctionDefinition(_id._idName);

            using (var smallContext = new Simple3ExecutionContext(ctx)){
                smallContext.AllocateParameters(def);

                if (_arguments.Count() == def.ParameterNames.Count){
                    for (int x = 0; x < def.ParameterNames.Count; x++){
                        // remember we have to evaluate the arguments IN THE PARENT CONTEXT
                        smallContext[def.ParameterNames[x].ToUpper()] = _arguments[x].GetValue(ctx);
                    }
                }

                foreach (Statement s in def.Body){
                    s.Execute(smallContext);
                }

                if (smallContext.ReturnValues.Count == 0){
                    throw new SimpleRuntimeException(string.Format("Function '{0}' did not return a value!", _id._idName));
                }

                return smallContext.ReturnValues.Pop();
            }
        }
    }
}