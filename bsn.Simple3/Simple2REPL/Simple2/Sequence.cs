using System.Collections;
using System.Collections.Generic;
using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple2{
    public class Sequence<T> : Simple2Token, IEnumerable<T> where T : Simple2Token{
        private readonly T item;
        private readonly Sequence<T> next;


        public Sequence()
            : this(null, null){
        }

        [Rule("<Statements> ::= <Statement>", typeof (Statement))]
        public Sequence(T item)
            : this(item, null){
        }


        [Rule("<Statements> ::= <Statement> <Statements>", typeof (Statement),
            ConstructorParameterMapping = new[] {0, 1})]
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