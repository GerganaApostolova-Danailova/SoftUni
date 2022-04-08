using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contestNAmePoint = 
                new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "no more time")
                {
                    break;
                }

                string[] input = command
                    .Split(" -> ")
                    .ToArray();

                string name = input[0];
                string course = input[1];
                int point = int.Parse(input[2]);

                if (!contestNAmePoint.ContainsKey(course))
                {
                    contestNAmePoint.Add(course, new Dictionary<string, int>());
                }
                if (!contestNAmePoint[course].ContainsKey(name))
                {
                    contestNAmePoint[course].Add(name, point);
                }
                if (contestNAmePoint[course][name] < point)
                {
                    contestNAmePoint[course][name] = point;
                }

            }


            foreach (var kvp in contestNAmePoint)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count} participants");

                var velue = kvp.Value;

                int count = 0;

                foreach (var item in velue.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
                {
                    count++;
                    Console.WriteLine($"{count}. {item.Key} <::> {item.Value}");
                }
            }

            Console.WriteLine("Individual standings:");

            Dictionary<string, int> newDict = new Dictionary<string, int>();

            string userName = string.Empty;

            foreach (var item in contestNAmePoint)
            {
                foreach (var kpd in item.Value)
                {
                    userName = kpd.Key;
                    if (!newDict.ContainsKey(userName))
                    {
                        newDict[userName] = 0;
                    }

                    newDict[userName] += kpd.Value;
                }
            }

            newDict = newDict
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            int count2 = 0;

            foreach (var item in newDict)
            {
                count2++;

                Console.WriteLine($"{count2}. {item.Key} -> {item.Value}");
            }

        }
    }
}
