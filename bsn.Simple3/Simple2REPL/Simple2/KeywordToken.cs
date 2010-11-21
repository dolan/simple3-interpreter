using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple2{
    [Terminal("assign")]
    [Terminal("display")]
    [Terminal("do")]
    [Terminal("else")]
    [Terminal("end")]
    [Terminal("if")]
    [Terminal("read")]
    [Terminal("then")]
    [Terminal("while")]
    public class KeywordToken : Simple2Token{
    }
}