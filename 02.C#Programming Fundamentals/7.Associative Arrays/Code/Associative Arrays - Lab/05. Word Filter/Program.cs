using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Word_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split()
                .Where(s => s.Length % 2 == 0)
                .ToList();

            for (int i = 0; i < input.Count; i++)
            {
                Console.WriteLine(input[i]);
            }
        }
    }
}
