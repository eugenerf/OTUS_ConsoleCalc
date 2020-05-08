using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalc
{
    class Multiply : Operands, IExpression
    {
        public Multiply() : base() { }

        public Multiply(IExpression left, IExpression right) : base(left, right) { }

        public double Interpret(Context context)
        {
            return leftOperand.Interpret(context) * rightOperand.Interpret(context);
        }
    }
}
