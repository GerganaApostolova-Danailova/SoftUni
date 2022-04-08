using System;
using System.Collections.Generic;
using System.Linq;

namespace Two
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
               .Split()
               .ToList();

            string command = Console.ReadLine();

            while (true)
            {
                if (command == "End")
                {
                    break;
                }

                string[] currant = command.Split().ToArray();

                if (currant[0] == "Join")
                {
                    string name = currant[1];

                    if (!list.Contains(name))
                    {
                        list.Add(name);
                    }
                }
                else if (currant[0] == "Jump")
                {
                    string name = currant[1];
                    int index = int.Parse(currant[2]);

                    if (!list.Contains(name) && index >= 0 && index < list.Count)
                    {
                        list.Insert(index, name);
                    }
                }
                else if (currant[0] == "Dive")
                {
                    int index = int.Parse(currant[1]);

                    if (index >= 0 && index < list.Count)
                    {
                        list.RemoveAt(index);

                    }
                }
                else if (currant[0] == "First")
                {
                    int currentNum = int.Parse(currant[1]);

                    if (currentNum < 0 && currentNum > list.Count)
                    {
                        Console.WriteLine(string.Join(" ", list));
                    }
                    else
                    {
                        for (int j = 0; j <= currentNum - 1; j++)
                        {
                            Console.Write(list[j] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                else if (currant[0] == "Last")
                {
                    int currentNum = int.Parse(currant[1]);

                    int num2 = list.Count - currentNum;

                    if (currentNum < 0 && currentNum > list.Count)
                    {
                        Console.WriteLine(string.Join(" ", list));
                    }
                    else
                    {
                    for (int j = num2; j < list.Count; j++)
                    {
                        Console.Write(list[j] + " ");
                    }
                    Console.WriteLine();
                    }
                }
                else if (currant[0] == "Print" && currant[1] == "Normal")
                {
                    break;
                }
                else if (currant[0] == "Print" && currant[1] == "Reversed")
                {
                    list.Reverse();
                    break;

                }
                command = Console.ReadLine();
            }

            Console.Write("Frogs: ");
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
