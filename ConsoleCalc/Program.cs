using System;
using System.Globalization;

namespace ConsoleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---== OTUS Console Calc ==---");
            double operand1 = GetNumber("Input the first operand");
            double operand2 = GetNumber("Input the second operand");

            Console.Write("\nChoose the operation (+,-,*,/,min,max): ");
            string operation = Console.ReadLine();

            double result = GetResult(operand1, operand2, operation);
            Console.WriteLine($"Result is: {result}");
            
            Console.Write("Any key to exit...");
            Console.ReadKey(true);
        }

        static double GetResult(double operand1, double operand2, string operation)
        {
            switch (operation)
            {
                case "+":
                    return operand1 + operand2;
                case "-":
                    return operand1 - operand2;
                case "*":
                    return operand1 * operand2;
                case "/":
                    return operand1 / operand2;
                case "min":
                    return GetMin(operand1, operand2);
                case "max":
                    return GetMax(operand1, operand2);
                default:
                    throw new InvalidOperationException();
            }
        }

        static double GetNumber(string text)
        {
            Console.Write(text + "_> ");
            string userInput = Console.ReadLine();
            double number = .0;
            double.TryParse(userInput, NumberStyles.Number, CultureInfo.InvariantCulture, out number);
            return number;
        }

        static double GetMax(double a, double b)
        {
            if (a > b) return a;
            else return b;
        }

        static double GetMin(double a, double b)
        {
            if (a < b) return a;
            else return b;
        }

        
    }
}
