using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _02._Practice_Sessions
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> roadsAndRacers = new Dictionary<string, List<string>>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                string[] splitedInput = command
                    .Split("->");

                if (splitedInput[0] == "Add")
                {
                    string road = splitedInput[1];
                    string racer = splitedInput[2];

                    if (!roadsAndRacers.ContainsKey(road))
                    {
                        roadsAndRacers.Add(road, new List<string>());
                    }

                        roadsAndRacers[road].Add(racer);

                }
                else if (splitedInput[0] == "Move")
                {
                    string currentRoad = splitedInput[1];
                    string racer = splitedInput[2];
                    string nextRoad = splitedInput[3];

                    if (roadsAndRacers[currentRoad].Contains(racer))
                    {
                        
                        roadsAndRacers[nextRoad].Add(racer);
                        roadsAndRacers[currentRoad].Remove(racer);
                    
                    }
                }
                else if (splitedInput[0] == "Close")
                {
                    string road = splitedInput[1];

                    if (roadsAndRacers.ContainsKey(road))
                    {
                        roadsAndRacers.Remove(road);
                    }
                }
            }

            Console.WriteLine("Practice sessions:");



            foreach (var race in roadsAndRacers.OrderByDescending(x => x.Value.Count).ThenBy(y => y.Key))
            {

                Console.WriteLine($"{race.Key}");

                foreach (var item in race.Value)
                {
                    Console.WriteLine($"++{item}");
                }


            }
        }
    }
}
