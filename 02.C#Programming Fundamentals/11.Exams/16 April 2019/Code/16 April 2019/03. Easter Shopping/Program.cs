using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Easter_Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                  .Split()
                  .ToList();

            int num = int.Parse(Console.ReadLine());

            
            for (int i = 0; i < num; i++)
            {

                string[] command = Console.ReadLine()
                    .Split();

                if (command[0] == "Include")
                {
                    input.Add(command[1]);
                }
                else if (command[0] == "Visit" && command[1] == "first")
                {
                    int currentNum = int.Parse(command[2]);

                    if (currentNum <= input.Count)
                    {
                        for (int j = 0; j < currentNum; j++)
                        {
                            input.RemoveAt(0);
                        } 
                    }
                }
                else if (command[0] == "Visit" && command[1] == "last")
                {
                    int currentNum = int.Parse(command[2]);

                    for (int j = 0; j < currentNum; j++)
                    {
                        input.RemoveAt(input.Count-1);
                    }
                }
                else if (command[0] == "Prefer")
                {
                    int index1 = int.Parse(command[1]);
                    int index2 = int.Parse(command[2]);

                    if (index1 < input.Count && index2 < input.Count)
                    {
                        string onIndex1 = input[index1];
                        string onIndex2 = input[index2];

                        string tempShop = onIndex1;

                        input.Remove(onIndex1);
                        input.Insert(index1, onIndex2);
                        input.RemoveAt(index2);
                        input.Insert(index2, onIndex1);

                    }
                }
                else if (command[0] == "Place")
                {
                    string word1 = command[1];
                    int index = int.Parse(command[2]);

                    if (index + 1 < input.Count)
                    {
                        input.Insert(index + 1, word1);
                    }
                }
            }
            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(" ",input));
        }
    }

}

