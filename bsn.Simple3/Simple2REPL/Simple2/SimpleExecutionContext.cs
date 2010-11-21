using System;
using System.Collections.Generic;
using System.IO;

namespace SimpleREPL.Simple2{
    public class SimpleExecutionContext : IDisposable{
        // we don't want to dispose of the console streams
        private readonly bool DoDisposeStreams;

        private readonly Dictionary<string, object> GlobalVariables = new Dictionary<string, object>();
        public TextReader InputStream;
        public TextWriter OutputStream;

        public SimpleExecutionContext(){
            InputStream = Console.In;
            OutputStream = Console.Out;
        }

        public SimpleExecutionContext(Stream input, Stream output){
            InputStream = new StreamReader(input);
            OutputStream = new StreamWriter(output);
            DoDisposeStreams = true;
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
                throw new UndefinedVariableException(uppperValue);
            }

            set{
                var upperValue = idx.ToUpper();
                GlobalVariables[upperValue] = value;
            }
        }
    }
}