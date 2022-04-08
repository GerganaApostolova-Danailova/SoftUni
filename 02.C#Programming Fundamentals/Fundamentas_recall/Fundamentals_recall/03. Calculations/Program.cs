using System;

namespace _03._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (command == "add")
            {
                PrintAddNumbers(a, b);
            }
            else if (command == "multiply")
            {
                PrintMultiplyNumbers(a, b);
            }
            else if (command == "subtract")
            {
                PrintSubtractNumbers(a, b);
            }
            else if (command == "divide")
            {
                PrintDevideNumbers(a, b);
            }
        }
        static void PrintDevideNumbers(int a, int b)
        {
            Console.WriteLine(a / b);

        }
        static void PrintSubtractNumbers(int a, int b)
        {
            Console.WriteLine(a - b);

        }
        static void PrintMultiplyNumbers(int a, int b)
        {
            Console.WriteLine(a * b);

        }
        static void PrintAddNumbers(int a, int b)
        {
            Console.WriteLine(a+b);
        }
    }
}
