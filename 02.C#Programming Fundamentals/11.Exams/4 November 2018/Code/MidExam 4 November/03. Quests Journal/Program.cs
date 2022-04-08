using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Quests_Journal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(", ")
                .ToList();

            string command = Console.ReadLine();

            while (true)
            {
                if (command == "Retire!")
                {
                    break;
                }

                string[] currunt = command.Split(" - ").ToArray();

                if (currunt[0] == "Start")
                {
                    string leson = currunt[1];

                    if (!list.Contains(leson))
                    {
                        list.Add(leson);
                    }
                }
                else if (currunt[0] == "Complete")
                {
                    string leson = currunt[1];

                    if (list.Contains(leson))
                    {
                        list.Remove(leson);
                    }
                }
                else if (currunt[0] == "Renew")
                {
                    string leson = currunt[1];

                    if (list.Contains(leson))
                    {
                        list.Remove(leson);
                        list.Add(leson);
                    }
                }
                else if (currunt[0] == "Side Quest")
                {

                    var helpList = currunt[1].Split(":");


                    string leson1 = helpList[0];
                    string leson2 = helpList[1];
                    
                    if (list.Contains(leson1))
                    {
                        int index = list.IndexOf(leson1);

                        if (index + 1 < list.Count)
                        {
                            if (!list.Contains(leson2)) //(list[index + 1] != leson2)
                            {
                                list.Insert(index + 1, leson2);
                            }
                        }
                        else
                        {
                            list.Add(leson2);
                        }
                    }

                }
                    command = Console.ReadLine();
            }
                Console.WriteLine(string.Join(", ", list));
        }
    }
}
