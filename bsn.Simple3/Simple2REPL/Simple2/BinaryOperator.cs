namespace SimpleREPL.Simple2{
    public abstract class BinaryOperator : Simple2Token{
        public abstract object Evaluate(object left, object right);
    }
}