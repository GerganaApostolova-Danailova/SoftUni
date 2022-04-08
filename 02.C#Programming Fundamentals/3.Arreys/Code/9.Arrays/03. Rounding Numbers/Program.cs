using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                double originalNumber = numbers[i];
                int roundedNumbers =(int) Math.Round(originalNumber, MidpointRounding.AwayFromZero);
                Console.WriteLine($"{originalNumber} => {roundedNumbers}");
            }
        }
    }
}
