namespace SimpleREPL.Simple2{
    public abstract class Statement : Simple2Token{
        public abstract void Execute(SimpleExecutionContext ctx);
    }
}