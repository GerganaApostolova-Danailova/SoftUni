using System;
using System.Collections.Generic;
using System.Linq;

namespace Easter_Gifts
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
                if (command == "No Money")
                {
                    break;
                }

                string[] currunt = command.Split().ToArray();

                if (currunt[0] == "OutOfStock")
                {
                    string gift = currunt[1];

                    for (int i = 0; i < list.Count; i++)
                    {
                        string insert = "None";

                        if (list[i] == gift)
                        {
                            list.Insert(i, insert);
                            list.Remove(gift);
                        }
                    }
                }
                else if (currunt[0] == "Required")
                {
                    string gift = currunt[1];
                    int index = int.Parse(currunt[2]);

                    if (index < list.Count && index >= 0)
                    {
                        string giftInIndex = list[index];
                        list.Insert(index, gift);
                        list.Remove(giftInIndex);
                    }
                }
                else if (currunt[0] == "JustInCase")
                {
                    string gift = currunt[1];

                    list.Remove(list[list.Count - 1]);
                    list.Add(gift);

                }
                command = Console.ReadLine();
            }
            for (int j = 0; j < list.Count; j++)
            {
                if (list[j] != "None")
                {
                    Console.Write(list[j] + " ");
                }
            }
        }
    }
}
