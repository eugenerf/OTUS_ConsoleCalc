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

            Console.WriteLine(ExpressionReader.ReadExpression("1+ 5 -9+6", ref expression, ref context));

            //IExpression testExpression = ExpressionReader.GetOperation("+").Invoke();
            //((Operands)testExpression).AddLeft(new Subtract());
            //((Operands)testExpression).AddRight(new Number("x"));

            //Context context = new Context();

            //context.SetVariable("x", 5);
            //context.SetVariable("y", 2);
            //context.SetVariable("z", 8);

            //IExpression expression = new Add(
            //    new Number("x"), new Subtract(
            //        new Number("y"), new Number("z")));

            //Console.WriteLine($"Result: {expression.Interpret(context)}");

            Console.Write("Any key to exit...");
            Console.ReadKey(true);
        }
    }
}
