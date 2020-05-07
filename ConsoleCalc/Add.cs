namespace ConsoleCalc
{
    /// <summary>
    /// Add operation (non terminal expression)
    /// </summary>
    class Add : IExpression
    {
        /// <summary>
        /// Left operand
        /// </summary>
        IExpression leftOperand;
        /// <summary>
        /// Right operand
        /// </summary>
        IExpression rightOperand;

        public Add(IExpression left, IExpression right)
        {
            leftOperand = left;
            rightOperand = right;
        }

        public double Interpret(Context context)
        {
            return leftOperand.Interpret(context) + rightOperand.Interpret(context);
        }
    }
}
