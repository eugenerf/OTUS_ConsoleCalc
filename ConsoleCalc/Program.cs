using System;
using System.Globalization;

namespace ConsoleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] operand = null;
            string userInput;

            Console.WriteLine("Input your operands (empty string to finish input):");
            do
            {
                int operandsEntered = (operand == null) ? 0 : operand.Length;
                Console.Write($"\t{operandsEntered + 1}: ");
                userInput = Console.ReadLine();
                if (userInput.Length == 0) break;
                Array.Resize<double>(ref operand, operandsEntered + 1);
                double.TryParse(userInput, NumberStyles.Number, CultureInfo.InvariantCulture, out operand[operandsEntered]);
            }
            while (true);

            Console.WriteLine($"\n\nYour operands:");
            for(int i = 0; i < operand.Length; i++)
                Console.WriteLine($"\t {i+1}: {operand[i]}");

            Console.Write("Any key to exit...");
            Console.ReadKey(true);
        }
    }
}
