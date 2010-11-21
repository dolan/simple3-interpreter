// /************************************************************
// *  
// * Copyright (c) 2010 Dave Dolan. All Rights Reserved
// *  
// *  Author: Dave Dolan
// *   
// ************************************************************/
using System.Collections;
using System.Collections.Generic;
using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple3{
    public class Sequence<T> : Simple3Token, IEnumerable<T> where T : Simple3Token{
        private readonly T item;
        private readonly Sequence<T> next;


        public Sequence()
            : this(null, null){
        }

        [Rule(@"<ParamList> ::= Id", typeof (Identifier))]
        [Rule(@"<ArgumentList> ::= <Expression>", typeof (Expression))]
        [Rule(@"<Statements> ::= <DelimitedStatement>", typeof (Statement))]
        public Sequence(T item)
            : this(item, null){
        }

        [Rule(@"<ParamList> ::= Id ~',' <ParamList>", typeof (Identifier))]
        [Rule(@"<ArgumentList> ::= <Expression> ~',' <ArgumentList>", typeof (Expression))]
        [Rule(@"<Statements> ::= <DelimitedStatement> <Statements>", typeof (Statement))]
        public Sequence(T item, Sequence<T> next){
            this.item = item;
            this.next = next;
        }

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator(){
            for (Sequence<T> sequence = this; sequence != null; sequence = sequence.next){
                if (sequence.item != null){
                    yield return sequence.item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator(){
            return GetEnumerator();
        }

        #endregion
    }
}