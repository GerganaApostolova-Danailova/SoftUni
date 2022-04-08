using System;

namespace _05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string order = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            if (order == "coffee")
            {
                PrintCoffeCost(count);
            }
            else if (order == "coke")
            {
                PrintCokeCost(count);
            }
            else if (order == "water")
            {
                PrintWaterCost(count);
            }
            else if (order == "snacks")
            {
                PrintSnackrCost(count);
            }
        }

        static void PrintSnackrCost(int count)
        {
            Console.WriteLine($"{(count * 2.00):f2}");
        }

        static void PrintWaterCost(double count)
        {
            Console.WriteLine($"{(count * 1.00):f2}");
        }

        static void PrintCokeCost(double count)
        {
            Console.WriteLine($"{(count * 1.40):f2}");
        }

        static void PrintCoffeCost(double count)
        {
            Console.WriteLine($"{(count * 1.50):f2}");
        }
    }
}
