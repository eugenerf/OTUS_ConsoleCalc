﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalc
{
    /// <summary>
    /// Number (terminal expression)
    /// </summary>
    class Number : IExpression
    {
        /// <summary>
        /// Variable name
        /// </summary>
        string name;

        public Number(string variableName)
        {
            name = variableName;
        }

        public double Interpret(Context context)
        {
            return context.GetVariable(name);
        }
    }
}
