using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalc
{
    class Root : Operands, IExpression
    {
        public Root() : base() { }
        public Root(IExpression left, IExpression right) : base(left, right) { }

        public double Interpret(Context context)
        {
            return Math.Pow(leftOperand.Interpret(context), 1.0 / rightOperand.Interpret(context));
        }
    }
}
