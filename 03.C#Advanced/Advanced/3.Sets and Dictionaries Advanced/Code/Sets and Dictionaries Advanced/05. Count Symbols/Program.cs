using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> dict = new SortedDictionary<char, int>();

            string line = Console.ReadLine();

            for (int i = 0; i < line.Length; i++)
            {
                if (!dict.ContainsKey(line[i]))
                {
                    dict.Add(line[i], 0);
                }
                dict[line[i]]++;
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
