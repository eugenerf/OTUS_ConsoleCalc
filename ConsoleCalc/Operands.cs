using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalc
{
    class Operands
    {
        /// <summary>
        /// Left operand
        /// </summary>
        internal protected IExpression leftOperand;
        /// <summary>
        /// Right operand
        /// </summary>
        internal protected IExpression rightOperand;

        public Operands()
        {
            leftOperand = null;
            rightOperand = null;
        }

        public Operands(IExpression left, IExpression right)
        {
            leftOperand = left;
            rightOperand = right;
        }

        public void AddLeft(IExpression left)
        {
            leftOperand = left;
        }

        public void AddRight(IExpression right)
        {
            rightOperand = right;
        }
    }
}
