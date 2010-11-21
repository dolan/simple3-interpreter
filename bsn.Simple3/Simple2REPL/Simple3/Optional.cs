// /************************************************************
// *  
// * Copyright (c) 2010 Dave Dolan. All Rights Reserved
// *  
// *  Author: Dave Dolan
// *   
// ************************************************************/
using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple3{
    public class Optional<T> : Simple3Token where T : Simple3Token{
        private readonly T value;


        [Rule(@"<OptionalParamList> ::=", typeof (Sequence<Identifier>))]
        [Rule(@"<OptionalArgumentList> ::=", typeof (Sequence<Expression>))]
        public Optional() : this(null){
        }

        [Rule(@"<OptionalParamList> ::= <ParamList>", typeof (Sequence<Identifier>))]
        [Rule(@"<OptionalArgumentList> ::= <ArgumentList>", typeof (Sequence<Expression>))]
        public Optional(T value){
            this.value = value;
        }

        public T Value{
            get { return value; }
        }

        public bool HasValue{
            get { return value != null; }
        }
    }
}