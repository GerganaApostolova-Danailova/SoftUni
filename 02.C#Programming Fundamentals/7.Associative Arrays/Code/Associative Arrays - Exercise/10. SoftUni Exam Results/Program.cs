using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> languagesAndName = new SortedDictionary<string, List<string>>();
            Dictionary<string, int> nameAndPoints = new Dictionary<string, int>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "exam finished")
                {
                    break;
                }

                string[] input = command
                    .Split("-")
                    .ToArray();

                string name = input[0];

                if (input[1] == "banned")
                {
                    nameAndPoints.Remove(name);
                }
                else
                {
                    string language = input[1];
                    int point = int.Parse(input[2]);

                    if (!languagesAndName.ContainsKey(language))
                    {
                        languagesAndName.Add(language, new List<string>());
                    }
                    if(languagesAndName.ContainsKey(language))
                    {
                    languagesAndName[language].Add(name);
                    }


                    if (!nameAndPoints.ContainsKey(name))
                    {
                        nameAndPoints.Add(name, point);
                    }
                    if (nameAndPoints.ContainsKey(name) && nameAndPoints[name] < point)
                    {
                        nameAndPoints[name] = point;
                    }

                }

            }

            nameAndPoints = nameAndPoints
                .OrderByDescending(x => x.Value)
                .ThenBy(x=>x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Results:");

            foreach (var name in nameAndPoints)
            {
                Console.WriteLine($"{name.Key} | {name.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var leng in languagesAndName)
            {
                Console.WriteLine($"{leng.Key} - {leng.Value.Count}");
            }
        }
    }
}
