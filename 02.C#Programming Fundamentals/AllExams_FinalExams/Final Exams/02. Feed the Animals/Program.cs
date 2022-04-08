using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _02._Feed_the_Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> nameFood = new Dictionary<string, int>();
            Dictionary<string, int> nameArea = new Dictionary<string, int>();


            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Last Info")
                {
                    break;
                }

                string[] splitedInput = input
                    .Split(":")
                    .ToArray();

                string comamnd = splitedInput[0];
                string name = splitedInput[1];
                int foodLimit = int.Parse(splitedInput[2]);
                string area = splitedInput[3];

                if (comamnd == "Add")
                {
                    if (!nameFood.ContainsKey(name))
                    {
                        nameFood.Add(name, foodLimit);

                        if (!nameArea.ContainsKey(area))
                        {
                            nameArea.Add(area, 1);
                        }
                        else
                        {
                            nameArea[area] += 1;
                        }
                    }
                    else
                    {
                        nameFood[name] += foodLimit;

                    }
                }
                else if (comamnd == "Feed")
                {
                    if (nameFood.ContainsKey(name))
                    {
                        if (nameFood[name] > foodLimit)
                        {
                            nameFood[name] -= foodLimit;
                        }
                        else if (nameFood[name] <= foodLimit)
                        {

                            nameFood.Remove(name);
                            Console.WriteLine($"{name} was successfully fed");

                            if (nameArea.ContainsKey(area))
                            {
                                if (nameArea[area] > 1)
                                {
                                    nameArea[area] -= 1;
                                }
                                else if (nameArea[area] <= 1)
                                {
                                    nameArea.Remove(area);
                                }
                            }
                        }

                    }
                }
            }

            Console.WriteLine("Animals:");

            foreach (var animal in nameFood.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{animal.Key} -> {animal.Value}g");
            }

            Console.WriteLine("Areas with hungry animals:");

            foreach (var area in nameArea.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{area.Key} : {area.Value}");
            }
        }
    }
}
