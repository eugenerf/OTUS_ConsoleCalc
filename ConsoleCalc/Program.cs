using System;
using System.Globalization;

namespace ConsoleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---== OTUS Console Calc ==---");
            while (true)
            {
                double operand1 = GetNumber("Input the first operand");
                double operand2 = GetNumber("Input the second operand");

                double result = .0;
                byte operationResult = 0;
                string operation;
                do
                {
                    Console.Write("\nChoose the operation (+,-,*,/,min,max): ");
                    operation = Console.ReadLine();
                    operationResult = GetResult(operand1, operand2, operation, out result);
                }
                while (operationResult >= 100);

                if (operationResult == 0)
                    Console.WriteLine($"Result is: {result}");
                else
                    Console.WriteLine("Result is: NaN");

                Console.Write("\n\nExit? [y/n] _> ");
                if (Console.ReadKey(false).Key == ConsoleKey.Y) return;
                Console.WriteLine("\n\n");
            }
        }

        static byte GetResult(double operand1, double operand2, string operation, out double result)
        {
            switch (operation)
            {
                case "+": result = operand1 + operand2; break;
                case "-": result = operand1 - operand2; break;
                case "*": result = operand1 * operand2; break;
                case "/":
                    if (operand2 == 0)
                    {
                        Console.WriteLine("ERROR! Division by zero!");
                        result = .0;
                        return 1;
                    }
                    else result = operand1 / operand2;
                    break;
                case "min": result = GetMin(operand1, operand2); break;
                case "max": result = GetMax(operand1, operand2); break;
                default:
                    Console.WriteLine("ERROR! Unknown operation!");
                    result = .0;
                    return 100;
            }
            return 0;
        }

        static double GetNumber(string text)
        {
            Console.Write(text + "_> ");
            string userInput = Console.ReadLine();
            double number = .0;
            while (!double.TryParse(userInput, NumberStyles.Number, CultureInfo.InvariantCulture, out number))
            {
                Console.Write("WRONG INPUT! Try again! _> ");
                userInput = Console.ReadLine();
            }
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
