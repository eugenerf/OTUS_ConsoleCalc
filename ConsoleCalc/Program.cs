using System;
using System.Globalization;

namespace ConsoleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---== eugene Console Calculator ==---");

            Context context = new Context();

            context.SetVariable("x", 5);
            context.SetVariable("y", 2);
            context.SetVariable("z", 8);

            IExpression expression = new Add(
                new Number("x"), new Subtract(
                    new Number("y"), new Number("z")));

            Console.WriteLine($"Result: {expression.Interpret(context)}");

            Console.Write("Any key to exit...");
            Console.ReadKey(true);
        }
    }
}
