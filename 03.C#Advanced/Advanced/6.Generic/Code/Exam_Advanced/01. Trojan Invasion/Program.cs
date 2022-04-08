using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Trojan_Invasion
{
    class Program
    {
        static void Main(string[] args)
        {
            int attacks = int.Parse(Console.ReadLine());

            List<int> spartansDefense = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Stack<int> troyanAttack = new Stack<int>();

            for (int i = 1; i <= attacks; i++)
            {
                if (spartansDefense.Count == 0)
                {
                    break;
                } 

                int[] attack = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

                if (i % 3 == 0)
                {
                    int moreDefense = int.Parse(Console.ReadLine());
                    spartansDefense.Add(moreDefense);
                }

                foreach (var war in attack)
                {
                    troyanAttack.Push(war);
                }

                while (spartansDefense.Any() && troyanAttack.Any())
                {
                    int defender = spartansDefense[0];
                    int attacker = troyanAttack.Pop();

                    if (defender > attacker)
                    {
                        defender -= attacker;
                        spartansDefense[0] = defender;

                    }
                    else if (defender == attacker)
                    {
                        spartansDefense.RemoveAt(0);
                    }
                    else
                    {
                        attacker -= defender;
                        spartansDefense.RemoveAt(0);
                        troyanAttack.Push(attacker);
                    }
                }
            }
            if (!spartansDefense.Any())
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.Write("Warriors left: ");
                Console.WriteLine(string.Join(", ", troyanAttack));
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.Write("Plates left: ");
                Console.Write(string.Join(", ", spartansDefense));
                Console.WriteLine();
            }
        }
    }
}

