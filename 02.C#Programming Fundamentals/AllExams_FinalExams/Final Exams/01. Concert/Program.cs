using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;


namespace _01._Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> nameAndMembers = new Dictionary<string, List<string>>();
            Dictionary<string, int> nameAndTime = new Dictionary<string, int>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "start of concert")
                {
                    break;
                }

                string[] input = command
                    .Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                string manipulation = input[0];
                string bandName = input[1];

                if (manipulation == "Play")
                {
                    int bandTime = int.Parse(input[2]);

                    if (!nameAndMembers.ContainsKey(bandName) && !nameAndTime.ContainsKey(bandName))
                    {
                        nameAndMembers.Add(bandName, new List<string>());
                        nameAndTime.Add(bandName, bandTime);
                    }
                    else
                    {
                        nameAndTime[bandName] += bandTime;
                    }
                }
                else if (manipulation == "Add")
                {
                    if (!nameAndMembers.ContainsKey(bandName) && !nameAndTime.ContainsKey(bandName))
                    {
                        nameAndMembers.Add(bandName, new List<string>());

                        for (int i = 2; i < input.Length; i++)
                        {
                            nameAndMembers[bandName].Add(input[i]);
                        }

                        nameAndTime.Add(bandName, 0);
                    }
                    else
                    {
                        for (int i = 2; i < input.Length; i++)
                        {
                            if (!nameAndMembers[bandName].Contains(input[i]))
                            {
                                nameAndMembers[bandName].Add(input[i]);
                            }

                        }
                        
                    }

                }

            }
            string finalinput = Console.ReadLine();

            int totalTime = 0;

            foreach (var point in nameAndTime)
            {
                totalTime += point.Value;
            }

            Console.WriteLine($"Total time: {totalTime}");

            foreach (var item in nameAndTime.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

            if (nameAndMembers.ContainsKey(finalinput))
            {
                foreach (var band in nameAndMembers)
                {
                    if (band.Key == finalinput)
                    {
                        Console.WriteLine($"{band.Key}");

                        foreach (var name in band.Value)
                        {
                            Console.WriteLine($"=> {name}");
                        }
                    }
                }
            }

        }
    }
}
