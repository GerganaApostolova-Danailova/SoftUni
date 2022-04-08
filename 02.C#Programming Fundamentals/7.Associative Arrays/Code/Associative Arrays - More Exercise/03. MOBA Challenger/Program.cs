using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> namePositionSkill = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Season end")
                {
                    break;
                }

                if (command.Contains("->"))
                {
                    string[] input = command
                        .Split(" -> ")
                        .ToArray();

                    string name = input[0];
                    string position = input[1];
                    int skill = int.Parse(input[2]);

                    if (!namePositionSkill.ContainsKey(name))
                    {
                        namePositionSkill.Add(name, new Dictionary<string, int>());
                    }
                    if (!namePositionSkill[name].ContainsKey(position))
                    {
                        namePositionSkill[name].Add(position, skill);
                    }
                    if (namePositionSkill[name][position] < skill)
                    {
                        namePositionSkill[name][position] = skill;
                    }
                }
                else if (command.Contains("vs"))
                {
                    string[] input = command
                       .Split(" vs ")
                       .ToArray();

                    string name1 = input[0];
                    string name2 = input[1];

                    if (namePositionSkill.ContainsKey(name1) && namePositionSkill.ContainsKey(name2))
                    {
                        string[] name1positions = namePositionSkill[name1].Keys.ToArray();

                        foreach (var pos2 in namePositionSkill[name2].Keys)
                        {
                            if (name1positions.Contains(pos2))
                            {
                                int totalSkillsfp = namePositionSkill[name1].Values.Sum();
                                int totalSkillssp = namePositionSkill[name2].Values.Sum();

                                if (totalSkillsfp > totalSkillssp)
                                {
                                    namePositionSkill.Remove(name2);
                                    break;
                                }
                                if (totalSkillsfp < totalSkillssp)
                                {
                                    namePositionSkill.Remove(name1);
                                    break;
                                }

                            }
                        }
                    }
                }

            }
            foreach (var kvp in namePositionSkill.OrderByDescending(x=> x.Value.Values.Sum()).ThenBy(y=>y.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Values.Sum()} skill");

                foreach (var item in kvp.Value.OrderByDescending(x=>x.Value).ThenBy(y=>y.Key))
                {
                    Console.WriteLine($"- {item.Key} <::> {item.Value}");
                }
            }
        }
    }
}
