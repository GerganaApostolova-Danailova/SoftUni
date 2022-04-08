using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> carsInParking = new SortedDictionary<string, List<string>>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] company = command.Split(" -> ").ToArray();

                string name = company[0];
                string number = company[1];

                if (!carsInParking.ContainsKey(name))
                {
                    carsInParking.Add(name, new List<string>());

                }
                if (!carsInParking[name].Contains(number))
                {
                   
                carsInParking[name].Add(number);

                }

            }

            foreach (var item in carsInParking)
            {
                Console.WriteLine($"{item.Key}");

                foreach (var num in item.Value)
                {
                Console.WriteLine($"-- {num}");

                }
            }
        }
    }
}
