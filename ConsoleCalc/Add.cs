using System;

namespace ConsoleCalc
{
    /// <summary>
    /// Add operation (non terminal expression)
    /// </summary>
    class Add : Operands, IExpression
    {
        public Add() : base() { }

        public Add(IExpression left, IExpression right) : base(left, right) { }

        public double Interpret(Context context)
        {
            return leftOperand.Interpret(context) + rightOperand.Interpret(context);
        }
    }
}
