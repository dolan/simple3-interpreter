using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SimpleREPL.Simple3 {
    [Serializable]
    public class TypeMismatchException : Exception{
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public TypeMismatchException(){
        }

        public TypeMismatchException(string message) : base(message){
        }

        public TypeMismatchException(string message, Exception inner) : base(message, inner){
        }

        protected TypeMismatchException(
            SerializationInfo info,
            StreamingContext context) : base(info, context){
        }
    }
}
