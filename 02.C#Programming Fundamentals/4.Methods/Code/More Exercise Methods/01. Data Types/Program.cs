using System;

namespace _01._Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            if (command == "int")
            {
                int num = int.Parse(Console.ReadLine());

                PrintIfItInt(num);
            }
            else if (command == "real")
            {
                double num = double.Parse(Console.ReadLine());

                PrintIfItDouble(num);
            }
            else if (command == "string")
            {
                string text = Console.ReadLine();

                PrintIfItString(text);
            }

        }

        private static void PrintIfItString(string text)
        {
            Console.WriteLine($"${text}$");
        }

        private static void PrintIfItDouble(double num)
        {
            double result = num * 1.5;
            Console.WriteLine($"{result:f2}");
        }

        static void PrintIfItInt(int num)
        {

            int result = num * 2;
            Console.WriteLine(result);
        }
    }
}
