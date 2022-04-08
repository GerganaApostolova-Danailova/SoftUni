using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Real_Numbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            SortedDictionary<int, int> output = new SortedDictionary<int, int>();

            foreach (var num in input)
            {
                if (output.ContainsKey(num))
                {
                    output[num]++;
                }
                else
                {
                    output[num] = 1;
                }
            }

            foreach (var num in output)
            {
                Console.WriteLine($"{num.Key} -> {num.Value}");
            }
        }
    }
}
