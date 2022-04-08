using System;
using System.Collections.Generic;
using System.Linq;


namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestPssword = new Dictionary<string, string>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(":");

                if (input[0] == "end of contests")
                {
                    break;
                }

                string contest = input[0];
                string password = input[1];

                if (!contestPssword.ContainsKey(contest))
                {
                    contestPssword.Add(contest, string.Empty);
                }

                contestPssword[contest] = password;
            }

            var nameAndContests = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string[] line = Console.ReadLine()
                    .Split("=>");

                if (line[0] == "end of submissions")
                {
                    break;
                }

                string contest = line[0];
                string password = line[1];
                string name = line[2];
                int point = int.Parse(line[3]);

                if (contestPssword.ContainsKey(contest) && contestPssword[contest] == password)
                {
                    if (!nameAndContests.ContainsKey(name))
                    {
                        nameAndContests.Add(name, new Dictionary<string, int>());

                    }
                    if (!nameAndContests[name].ContainsKey(contest))
                    {
                        nameAndContests[name][contest] = 0;
                    }
                    if (nameAndContests[name][contest] < point)
                    {

                        nameAndContests[name][contest] = point;
                    }
                }
            }

            Dictionary<string, int> usersTootalPoints = new Dictionary<string, int>();

            foreach (var kvp in nameAndContests)
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

            Console.WriteLine("Ranking:");

            foreach (var kvp in nameAndContests)
            {
                Console.WriteLine(kvp.Key);

                foreach (var kvp2 in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {kvp2.Key} -> {kvp2.Value}");
                }
            }
        }
    }
}
