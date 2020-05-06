namespace ConsoleCalc
{
    /// <summary>
    /// Subtract operation
    /// </summary>
    class Subtract : IExpression
    {
        /// <summary>
        /// Left operand
        /// </summary>
        IExpression leftOperand;
        /// <summary>
        /// Right operand
        /// </summary>
        IExpression rightOperand;

        public Subtract(IExpression left, IExpression right)
        {
            leftOperand = left;
            rightOperand = right;
        }

        public double Interpret(Context context)
        {
            return leftOperand.Interpret(context) - rightOperand.Interpret(context);
        }
    }
}
