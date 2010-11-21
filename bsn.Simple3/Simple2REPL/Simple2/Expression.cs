namespace SimpleREPL.Simple2{
    public abstract class Expression : Simple2Token{
        public abstract object GetValue(SimpleExecutionContext ctx);
    }
}