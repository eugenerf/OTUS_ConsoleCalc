using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalc
{
    class Power : Operands, IExpression
    {
        public Power() : base() { }
        public Power(IExpression left, IExpression right) : base(left, right) { }

        public double Interpret(Context context)
        {
            return Math.Pow(leftOperand.Interpret(context), rightOperand.Interpret(context));
        }
    }
}
