using System;
using System.Globalization;

namespace ConsoleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---== eugene Console Calculator (using the Interpreter pattern)==---");

            ExpressionReader.AddOperation('+', () => { return new Add(); });
            ExpressionReader.AddOperation('-', () => { return new Subtract(); });

            Context context = null;
            IExpression expression = null;

            string strExpression = "1-5";

            ExpressionReader.ReadExpression(strExpression, ref expression, ref context);

            Console.WriteLine(strExpression + " = " + expression.Interpret(context).ToString());

            Console.Write("Any key to exit...");
            Console.ReadKey(true);
        }
    }
}
