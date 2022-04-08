using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> validItems = new Dictionary<string, int>();

            SortedDictionary<string, int> junkItems = new SortedDictionary<string, int>();

            validItems.Add("fragments", 0);
            validItems.Add("shards", 0);
            validItems.Add("motes", 0);


            bool isValid = true;


            while (isValid)
            {
                string[] line = Console.ReadLine()
                    .ToLower()
                    .Split()
                    .ToArray();

                for (int i = 0; i < line.Length-1; i+=2)
                {
                    int quantity = int.Parse(line[i]);
                    string material = line[i + 1];

                    if (validItems.ContainsKey(material))
                    {
                        validItems[material] += quantity;

                        if (validItems[material] >= 250)
                        {
                            isValid = false;
                            validItems[material] -= 250;

                            if (material == "fragments")
                            {
                                Console.WriteLine("Valanyr obtained!");
                                break;
                            }
                            else if (material == "shards")
                            {
                                Console.WriteLine("Shadowmourne obtained!");
                                break;
                            }
                            else if (material == "motes")
                            {
                                Console.WriteLine("Dragonwrath obtained!");
                                break;
                            }
                            break;
                        }
                    }
                    else
                    {
                        if (junkItems.ContainsKey(material))
                        {
                            junkItems[material] += quantity;
                        }
                        else
                        {
                        junkItems.Add(material, quantity);
                                
                        }
                    }
                }

            }
                var sortedItems = validItems.OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key);

                foreach (var item in sortedItems)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }

                foreach (var junk in junkItems)
                {
                    Console.WriteLine($"{junk.Key}: {junk.Value}");
                }
        }
    }
}
