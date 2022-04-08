using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> dict = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < num; i++)
            {
                string[] line = Console.ReadLine()
                    .Split();

                string continent= line[0];
                string country = line[1];
                string city = line[2];

                if (!dict.ContainsKey(continent))
                {
                    dict.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!dict[continent].ContainsKey(country))
                {
                    dict[continent][country] = new List<string>();
                }

                dict[continent][country].Add(city);
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key}:");

                foreach (var item in kvp.Value)
                {
                    Console.WriteLine($"  {item.Key} -> {string.Join(", ", item.Value)}");
                }
            }
        }
    }
}
