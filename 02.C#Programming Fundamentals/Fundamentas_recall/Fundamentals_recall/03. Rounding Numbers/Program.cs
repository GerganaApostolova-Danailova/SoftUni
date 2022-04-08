using System;
using System.Linq;

namespace _03._Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            foreach (var item in arr)
            {
                int output = (int)Math.Round(item, 0, MidpointRounding.AwayFromZero);
                Console.WriteLine($"{item} => {output}");
            }

        }
    }
}
