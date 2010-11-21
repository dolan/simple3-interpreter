// /************************************************************
// *  
// * Copyright (c) 2010 Dave Dolan. All Rights Reserved
// *  
// *  Author: Dave Dolan
// *   
// ************************************************************/
using System;
using System.Collections.Generic;
using System.IO;

namespace SimpleREPL.Simple3{
    public class Simple3ExecutionContext : IDisposable{
        // we don't want to dispose of the console streams
        private readonly bool DoDisposeStreams;
        internal Stack<object> ReturnValues;

        private readonly Dictionary<string, object> GlobalVariables = new Dictionary<string, object>();

        private readonly Dictionary<string, FunctionDefinition> DispatchTable =
            new Dictionary<string, FunctionDefinition>();

        private readonly Simple3ExecutionContext parentContext;

        public TextReader InputStream;
        public TextWriter OutputStream;

        public Simple3ExecutionContext(){
            InputStream = Console.In;
            OutputStream = Console.Out;
            ReturnValues = new Stack<object>();
        }

        public Simple3ExecutionContext(Stream input, Stream output){
            InputStream = new StreamReader(input);
            OutputStream = new StreamWriter(output);
            DoDisposeStreams = true;
            ReturnValues = new Stack<object>();
        }

        public Simple3ExecutionContext(Simple3ExecutionContext parent){
            parentContext = parent;
            InputStream = parent.InputStream;
            OutputStream = parent.OutputStream;
            DoDisposeStreams = false;

            // just need one stack for all scopes, that's why it's a stack and not just a single variable.
            ReturnValues = parent.ReturnValues;
        }

        internal void AllocateParameters(FunctionDefinition def){
            foreach (var s in def.ParameterNames){
                GlobalVariables.Add(s, ""); // making it empty, prevent from spilling to parent ctx
            }
        }

        internal void DefineFunction(string name, FunctionDefinition def){
            DispatchTable[name.ToUpper()] = def;
        }

        internal FunctionDefinition GetFunctionDefinition(string name){
            string upperName = name.ToUpper();

            /* 
             * This behavior is one of the things that makes 'Simple 3' interesting.
             * You can have functions nested in scope, masking those of the parent scopes.
             * If you call one that is not in this scope, it will check the parent scope,
             * going up several levels if it has to.
             */

            if (! DispatchTable.ContainsKey(upperName)){
                if (parentContext != null){
                    return parentContext.GetFunctionDefinition(upperName);
                }

                throw new SimpleRuntimeException(string.Format("Call to undefined function '{0}'", name));
            }
            return DispatchTable[upperName];
        }

        #region IDisposable Members

        public void Dispose(){
            if (DoDisposeStreams){
                OutputStream.Dispose();
                InputStream.Dispose();
            }
        }

        #endregion

        public object this[string idx]{
            get{
                var uppperValue = idx.ToUpper();
                if (GlobalVariables.ContainsKey(uppperValue)){
                    return GlobalVariables[uppperValue];
                }
                else if (parentContext != null){
                    // check the parent, if we get to the top and nobody has it, the below exception will be thrown
                    return parentContext[uppperValue];
                }
                throw new UndefinedVariableException(uppperValue);
            }

            set{
                var upperValue = idx.ToUpper();
                if (parentContext != null){
                    if (!GlobalVariables.ContainsKey(upperValue)){
                        //NOTE: this is messy, the get is simple. I'm not 100% sure how to handle this.

                        // if we don't have this variable yet, but the parent does...
                        // use the parent contexts reference instead

                        if (parentContext.GlobalVariables.ContainsKey(upperValue)){
                            parentContext[upperValue] = value;
                            return;
                        }
                    }
                }

                GlobalVariables[upperValue] = value;
            }
        }
    }
}