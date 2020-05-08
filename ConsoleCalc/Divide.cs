namespace ConsoleCalc
{
    class Divide : Operands, IExpression
    {
        public Divide() : base() { }

        public Divide(IExpression left, IExpression right) : base(left, right) { }

        public double Interpret(Context context)
        {
            return leftOperand.Interpret(context) / rightOperand.Interpret(context);
        }
    }
}
