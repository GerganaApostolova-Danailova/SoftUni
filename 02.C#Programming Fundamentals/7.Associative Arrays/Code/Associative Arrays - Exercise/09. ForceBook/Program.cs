using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> sideMember = new Dictionary<string, List<string>>();
           

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Lumpawaroo")
                {
                    break;
                }

                if (command.Contains("|"))
                {
                string[] sideAndName = command
                    .Split(" | ")
                    .ToArray();

                    string side = sideAndName[0];
                    string name = sideAndName[1];

                    if (!sideMember.ContainsKey(side))
                    {
                        sideMember.Add(side, new List<string>());
                    }
                    bool isThere = false;

                    foreach (var kvp in sideMember)
                    {
                        if (kvp.Value.Contains(name))
                        {
                            isThere = true;
                            break;
                        }
                    }
                    if (!sideMember[side].Contains(name) && !isThere)
                    {
                        sideMember[side].Add(name);
                    }
                    
                }
                else 
                {
                    string[] sideAndName = command
                    .Split(" -> ")
                    .ToArray();

                    string side = sideAndName[1];
                    string name = sideAndName[0];

                    bool isThere = false;
                    string currentSide = string.Empty;

                    foreach (var kvp in sideMember)
                    {
                        if (kvp.Value.Contains(name))
                        {
                            isThere = true;
                            currentSide = kvp.Key;
                            break;
                        }

                    }

                    if (isThere)
                    {
                    sideMember[currentSide].Remove(name);
                       
                    }
                    if (!sideMember.ContainsKey(side))
                    {
                        sideMember.Add(side, new List<string>());
                    }
                    if (!sideMember[side].Contains(name))
                    {
                        sideMember[side].Add(name);
                    }
                        Console.WriteLine($"{name} joins the {side} side!");
                }
            }

            sideMember = sideMember
                .Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in sideMember)
            {
                string side = item.Key;
                List<string> soldiers = item.Value.OrderBy(s => s).ToList();

                Console.WriteLine($"Side: {side}, Members: {soldiers.Count}");

                foreach (var kvp in soldiers)
                {
                    Console.WriteLine($"! {kvp}");
                }
            }
        }
    }
}
