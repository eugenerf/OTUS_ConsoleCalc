using System;
using System.Globalization;

namespace ConsoleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---== eugene Console Calculator (using the Interpreter pattern)==---");
            Console.WriteLine("\nList of available operations:");
            Console.WriteLine("+\taddition (using: 1+2)");
            Console.WriteLine("-\tsubtraction (using: 1-2)");
            Console.WriteLine("*\tmultiplication (using: 1*2)");
            Console.WriteLine("/\tdivision (using: 1/2)");
            Console.WriteLine("^\tpower (using: 1^2)");
            Console.WriteLine("v\troot (using: 1v2)");
            Console.WriteLine("\nEnter the expression using available operations and numbers.");
            Console.WriteLine("Then press <Enter> to calculate.\n");

            ExpressionReader.AddOperation('+', () => { return new Add(); });
            ExpressionReader.AddOperation('-', () => { return new Subtract(); });
            ExpressionReader.AddOperation('*', () => { return new Multiply(); }, 1);
            ExpressionReader.AddOperation('/', () => { return new Divide(); }, 1);
            ExpressionReader.AddOperation('^', () => { return new Power(); }, 2);
            ExpressionReader.AddOperation('v', () => { return new Root(); }, 2);

            Context context = null;
            IExpression expression = null;

            string strExpression = Console.ReadLine();

            if (ExpressionReader.ReadExpression(strExpression, ref expression, ref context))
            {
                Console.WriteLine("\nExpression result is: " + expression.Interpret(context).ToString());
            }
            else
            {
                Console.WriteLine("ERROR! Expression format unknown. Cannot calculate.");
            }

            Console.Write("Any key to exit...");
            Console.ReadKey(true);
        }
    }
}
