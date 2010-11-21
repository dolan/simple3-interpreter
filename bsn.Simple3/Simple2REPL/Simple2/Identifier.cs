using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple2{
    [Terminal("Id")]
    public class Identifier : Expression{
        internal readonly string _idName;

        public Identifier(string idName){
            _idName = idName;
        }

        public override object GetValue(SimpleExecutionContext ctx){
            return ctx[_idName];
        }
    }
}