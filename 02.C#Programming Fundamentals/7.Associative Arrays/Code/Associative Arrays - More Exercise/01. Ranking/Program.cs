using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestAndPass = new Dictionary<string, string>();


            while (true)
            {

                string command1 = Console.ReadLine();

                if (command1 == "end of contests")
                {
                    break;
                }

                if (command1.Contains(":"))
                {
                    string[] input1 = command1
                        .Split(":")
                        .ToArray();

                    string contest = input1[0];
                    string pass = input1[1];

                    contestAndPass.Add(contest, pass);
                }
            }

            SortedDictionary<string, Dictionary<string, int>> nameCoursPoints = new SortedDictionary<string, Dictionary<string, int>>();


            while (true)
            {
            string command2 = Console.ReadLine();

                if (command2 == "end of submissions")
                {
                    break;
                }
                if (command2.Contains("=>"))
                {
                    string[] input2 = command2
                        .Split("=>")
                        .ToArray();

                    string contest = input2[0];
                    string pass = input2[1];
                    string name = input2[2];
                    int points = int.Parse(input2[3]);

                    if (contestAndPass.ContainsKey(contest) && contestAndPass[contest] == pass)
                    {
                        if (!nameCoursPoints.ContainsKey(name))
                        {
                            nameCoursPoints.Add(name, new Dictionary<string, int>());

                            nameCoursPoints[name].Add(contest, points);

                        }
                        else
                        {
                            if (!nameCoursPoints[name].ContainsKey(contest))
                            {
                                nameCoursPoints[name].Add(contest, points);
                            }
                            else
                            {
                                if (nameCoursPoints[name][contest] < points)
                                {
                                    nameCoursPoints[name][contest] = points;
                                }
                            }
                        }

                    }
                }

            }

            Dictionary<string, int> usersTootalPoints = new Dictionary<string, int>();

            foreach (var kvp in nameCoursPoints)
            {
                usersTootalPoints[kvp.Key] = kvp.Value.Values.Sum();
            }

            int maxPoints = usersTootalPoints
                .Values
                .Max();

            foreach (var kvp in usersTootalPoints)
            {
                if (kvp.Value == maxPoints)
                {
                    Console.WriteLine($"Best candidate is {kvp.Key} with total {kvp.Value} points.");

                }
            }
            Console.WriteLine("Ranking: ");

            foreach (var kvp in nameCoursPoints)
            {
                Console.WriteLine($"{kvp.Key}");

                foreach (var item in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}
