using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(x => x > 0)
                .Reverse()
                .ToList();

            if (input.Count == 0)
            {
                Console.WriteLine("empty");
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
