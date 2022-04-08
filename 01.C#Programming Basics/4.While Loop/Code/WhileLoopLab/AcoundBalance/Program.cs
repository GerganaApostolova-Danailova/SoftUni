using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcoundBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double balanse = 0.0;
            int count = 0;

            while (count < n)
            {

                double amount = double.Parse(Console.ReadLine());

                if (amount < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                balanse += amount;
                Console.WriteLine($"Increase: {amount:f2}");
                count++;
            }
            Console.WriteLine($"Total: {balanse:f2}");
        }
    }
}
