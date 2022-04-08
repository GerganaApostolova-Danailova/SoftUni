using System;

namespace _05._Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int k = 1;

            double sum = 0;

            while (k <= num)
            {
                double payment = double.Parse(Console.ReadLine());

                if (payment < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                Console.WriteLine($"Increase: {payment:F2}");

                sum += payment;

                k++;

            }

            Console.WriteLine($"Total: {sum:F2}");
        }
    }
}
