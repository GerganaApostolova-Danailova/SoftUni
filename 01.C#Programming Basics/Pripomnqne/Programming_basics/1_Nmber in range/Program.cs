using System;

namespace _1_Nmber_in_range
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            while (number < 1 || number > 100)
            {
                Console.WriteLine("Invalid number!");

                number = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"The number is: {number}");
        }
    }
}
