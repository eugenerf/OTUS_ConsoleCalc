using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalc
{
    /// <summary>
    /// Reads the expression from string to the expression tree
    /// </summary>
    static class ExpressionReader
    {
        /// <summary>
        /// Available operations dictionary
        /// </summary>
        static private Dictionary<char, Func<IExpression>> operations = null;
        /// <summary>
        /// Available operations sorted by their priorities
        /// </summary>
        static private char[][] byPriority = null;

        /// <summary>
        /// Adds operation to the dictionary
        /// </summary>
        /// <param name="symbol">Operation symbol</param>
        /// <param name="expression">Operation expression ctor</param>
        /// <param name="priority">Operation priority (0 - minimal)</param>
        static public void AddOperation(char symbol, Func<IExpression> expression, uint priority = 0)
        {
            if (operations == null) operations = new Dictionary<char, Func<IExpression>>();
            if (byPriority == null) byPriority = new char[priority + 1][];
            if (byPriority.Length <= priority) Array.Resize(ref byPriority, (int)priority + 1);
            if (operations.ContainsKey(symbol))
            {
                operations[symbol] = expression;
                DeleteSymbolFromPriority(symbol);
            }
            else
            {
                operations.Add(symbol, expression);
            }
            AddSymbolByPriority(symbol, priority);

        }

        private static void DeleteSymbolFromPriority(char symbol)
        {
            for (int i = 0; i < byPriority.Length; i++)
            {
                for (int j = 0; j < byPriority[i].Length; j++)
                {
                    if (byPriority[i][j] == symbol)
                    {
                        byPriority[i][j] = '\0';
                        return;
                    }
                }
            }
        }

        static private void AddSymbolByPriority(char symbol, uint priority)
        {
            int index = (byPriority[priority] == null) ? 0 : byPriority[priority].Length;
            Array.Resize(ref byPriority[priority], index + 1);
            byPriority[priority][index] = symbol;
        }

        /// <summary>
        /// Gets the operation expression from the dictionary by its symbol
        /// </summary>
        /// <param name="symbol">Operation symbol</param>
        /// <returns>Operation expression ctor</returns>
        static public Func<IExpression> GetOperation(char symbol)
        {
            return operations[symbol];
        }

        /// <summary>
        /// Reads the expression from the source. Result is stored to the expression and context
        /// </summary>
        /// <param name="source">Source string</param>
        /// <param name="expression">Result expression tree</param>
        /// <param name="context">Result expression context</param>
        /// <returns>TRUE if read successfully</returns>
        static public bool ReadExpression(string source, ref IExpression expression, ref Context context)
        {
            context = null;
            expression = null;

            source = source.Replace(" ", "");
            source = source.Replace(
                CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, 
                CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
            if (!CheckString(source)) return false;

            context = new Context();

            return ReadRecursively(source, ref expression, ref context, 0, 0); ;
        }

        private static bool ReadRecursively(string source, ref IExpression expression, ref Context context, uint curPriority, uint curOperation)
        {
            if (curPriority >= byPriority.Length)
            {
                double variableValue = .0;
                string variableName = "";                
                if (!double.TryParse(source, NumberStyles.Any, CultureInfo.InvariantCulture, out variableValue))
                    return false;
                variableName = context.AddVariable(variableValue);
                expression = new Number(variableName);
                return true;
            }
            if (curOperation >= byPriority[curPriority].Length)
            {
                return ReadRecursively(source, ref expression, ref context, curPriority + 1, 0); ;
            }

            int operationIndexInSource = source.IndexOf(byPriority[curPriority][curOperation]);
            if (operationIndexInSource == -1)
            {
                return ReadRecursively(source, ref expression, ref context, curPriority, curOperation + 1); ;
            }

            expression = operations[byPriority[curPriority][curOperation]].Invoke();
            string leftSource = source.Substring(0, operationIndexInSource);
            IExpression leftExpression = null;
            bool leftResult = ReadRecursively(leftSource, ref leftExpression, ref context, curPriority, curOperation);
            ((Operands)expression).AddLeft(leftExpression);

            string rightSource = source.Substring(operationIndexInSource + 1, source.Length - operationIndexInSource - 1);
            IExpression rightExpression = null;
            bool rightResult = ReadRecursively(rightSource, ref rightExpression, ref context, curPriority, curOperation);
            ((Operands)expression).AddRight(rightExpression);

            return leftResult && rightResult;
        }

        /// <summary>
        /// Checks the source string for expression grammar
        /// </summary>
        /// <param name="source">String to be checked</param>
        /// <returns>TRUE if string is OK</returns>
        static bool CheckString(string source)
        {
            foreach (char c in source)
                if (!char.IsDigit(c) &&
                    !(c == '.' || c == ',') &&
                    !operations.ContainsKey(c))
                    return false;
            return true;
        }
    }
}
