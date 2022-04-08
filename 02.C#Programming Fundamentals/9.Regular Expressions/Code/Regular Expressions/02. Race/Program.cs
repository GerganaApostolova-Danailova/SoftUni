using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> racers = Console.ReadLine()
                .Split(", ")
                .ToList();

            string namePattern = @"[A-Za-z]";
            string pointsPattern = @"\d";

            string command = Console.ReadLine();

            Dictionary<string, int> namePoints = new Dictionary<string, int>();

            while (command != "end of race")
            {
            StringBuilder sb = new StringBuilder();

                string name = string.Empty;
                int sum = 0;
                MatchCollection matchName = Regex.Matches(command, namePattern);

                foreach (Match item in matchName)
                {
                    sb.Append(item.Value);
                }

                MatchCollection matchPoint = Regex.Matches(command, pointsPattern);

                foreach (Match point in matchPoint)
                {
                    int digit = int.Parse(point.Value);
                    sum += digit;
                }

                if (racers.Contains(sb.ToString()))
                {
                   name = sb.ToString();

                    if (!namePoints.ContainsKey(name))
                    {

                        namePoints[name] = 0;
                    }

                    namePoints[name] += sum;
                }

                command = Console.ReadLine();
            }

            namePoints = namePoints.OrderByDescending(x => x.Value)
                .Take(3)
                .ToDictionary(x => x.Key, y => y.Value);

            var result = namePoints.Keys.ToList();

            Console.WriteLine($"1st place: {result[0]}");
            Console.WriteLine($"2nd place: {result[1]}");
            Console.WriteLine($"3rd place: {result[2]}");
        }
    }
}
