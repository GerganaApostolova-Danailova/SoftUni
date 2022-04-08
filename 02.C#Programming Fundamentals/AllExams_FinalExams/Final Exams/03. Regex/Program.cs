using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _03._Regex
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> nameHealtEnergy = new Dictionary<string, List<int>>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Results")
                {
                    break;
                }

                string[] command2 = command
                    .Split(":");

                string manipulation = command2[0];

                if (manipulation == "Add")
                {
                    string personName = command2[1];
                    int health =int.Parse(command2[2]);
                    int energy = int.Parse(command2[3]);

                    if (!nameHealtEnergy.ContainsKey(personName))
                    {
                        nameHealtEnergy.Add(personName, new List<int>());
                        nameHealtEnergy[personName].Add(health);
                        nameHealtEnergy[personName].Add(energy);
                    }
                    else
                    {
                        nameHealtEnergy[personName][0] += health;
                    }
                }
                else if (manipulation == "Attack")
                {
                    string attackerName = command2[1];
                    string defenderName = command2[2];
                    int damage = int.Parse(command2[3]);

                    if (nameHealtEnergy.ContainsKey(attackerName) && nameHealtEnergy.ContainsKey(defenderName))
                    {
                        
                        nameHealtEnergy[defenderName][0] -= damage;
                        nameHealtEnergy[attackerName][1] -= 1;

                        if (nameHealtEnergy[defenderName][0] <= 0)
                        {
                            nameHealtEnergy.Remove(defenderName);
                            Console.WriteLine($"{defenderName} was disqualified!");
                        }
                        if (nameHealtEnergy[attackerName][1] == 0)
                        {
                            nameHealtEnergy.Remove(attackerName);
                            Console.WriteLine($"{attackerName} was disqualified!");
                        }
                    }
                    
                }
                else if (manipulation == "Delete")
                {
                    string username = command2[1];

                    if (username == "All")
                    {
                        nameHealtEnergy.Clear();
                    }
                    else
                    {
                        if (nameHealtEnergy.ContainsKey(username))
                        {
                            nameHealtEnergy.Remove(username);
                        }
                    }
                }
            }

            //int count = 0;

            //foreach (var kvp in nameHealtEnergy)
            //{
            //    count++;
            //}

            //Console.WriteLine($"People count: {count}");

            Console.WriteLine($"People count: {nameHealtEnergy.Count}");

            Dictionary<string, int> help = new Dictionary<string, int>();

            foreach (var item in nameHealtEnergy)
            {
                help.Add(item.Key, item.Value[0]);
            }

            var sortedHelp = help.OrderByDescending(x => x.Value).ThenBy(y => y.Key);

            foreach (var kvp in sortedHelp)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} - {nameHealtEnergy[kvp.Key][1]}");
            }

            //foreach (var item in nameHealtEnergy.OrderByDescending(x=>x.Value[0]).ThenByDescending(y=>y.Key))
            //{
            //    Console.WriteLine($"{item.Key} - {item.Value[0]} - {item.Value[1]}");
            //}
        }
    }               
}
