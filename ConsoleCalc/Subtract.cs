namespace ConsoleCalc
{
    /// <summary>
    /// Subtract operation
    /// </summary>
    class Subtract : Operands, IExpression
    {
        public Subtract() : base() { }

        public Subtract(IExpression left, IExpression right) : base(left, right) { }

        public double Interpret(Context context)
        {
            return leftOperand.Interpret(context) - rightOperand.Interpret(context);
        }
    }
}
