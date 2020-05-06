using System;
using System.Globalization;

namespace ConsoleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] operand = new double[1];

            Console.Write("Input the first number: ");
            string userInput = Console.ReadLine();
            double.TryParse(userInput, NumberStyles.Number, CultureInfo.InvariantCulture, out operand[0]);

            Console.Write("Input the second number: ");
            userInput = Console.ReadLine();
            Array.Resize<double>(ref operand, operand.Length + 1);
            double.TryParse(userInput, NumberStyles.Number, CultureInfo.InvariantCulture, out operand[1]);

            Console.WriteLine($"\n\nYour operands:");
            for(int i = 0; i < operand.Length; i++)
                Console.WriteLine($"\t {i+1}: {operand[i]}");

            Console.Write("Any key to exit...");
            Console.ReadKey(true);
        }
    }
}
