using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Santa_s_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split("&")
                .ToList();

            string command = Console.ReadLine();

            while (true)
            {
                if (command == "Finished!")
                {
                    break;
                }

                string[] currunt = command.Split().ToArray();

                if (currunt[0] == "Bad")
                {
                    string kidName = currunt[1];

                    if (!list.Contains(kidName))
                    {
                        list.Insert(0, kidName);
                    }
                }
                else if (currunt[0] == "Good")
                {
                    string kidName = currunt[1];

                    if (list.Contains(kidName))
                    {
                        list.Remove(kidName);
                    }
                }
                else if (currunt[0] == "Rename")
                {
                    string kidName = currunt[1];
                    string newKidName = currunt[2];

                    if (list.Contains(kidName))
                    {
                       int index= list.IndexOf(kidName);
                        list.Insert(index, newKidName);
                        list.Remove(kidName);
                    }
                }
                else if (currunt[0] == "Rearrange")
                {
                    
                    string kidName = currunt[1];

                    if (list.Contains(kidName))
                    {
                        list.Remove(kidName);
                        list.Add(kidName);
                    }

                }
                
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
