using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().
                Split().
                ToList();

            while (true)
            {

                string command = Console.ReadLine();

                if (command == "3:1")
                {
                    break;
                }

                string[] currentInput = command.Split();

                if (currentInput[0] == "merge")
                {
                    int startIndex = int.Parse(currentInput[1]);
                    int endIndex = int.Parse(currentInput[2]);

                    string newItem = string.Empty;

                    if (startIndex < 0 || startIndex > input.Count - 1)
                    {
                        startIndex = 0;
                    }
                    if (endIndex > input.Count - 1 || endIndex < 0)
                    {
                        endIndex = input.Count - 1;
                    }
                    if (input.Count > 0)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            newItem += input[i];
                        }
                        input.RemoveRange(startIndex, (endIndex - startIndex) + 1);
                        input.Insert(startIndex, newItem);
                    }

                }
                else if (currentInput[0] == "divide")
                {
                    List<string> temp = new List<string>();


                    string toDivide = input[int.Parse(currentInput[1])];
                    int partitions = int.Parse(currentInput[2]);

                    int partLength = toDivide.Length / int.Parse(currentInput[2]);
                    int additionalPartLength = toDivide.Length % int.Parse(currentInput[2]);
                    for (int i = 0; i < partitions; i++)
                    {
                        if (i == partitions - 1)
                        {
                            partLength += additionalPartLength;
                        }

                        temp.Add(toDivide.Substring(0, partLength));
                        toDivide = toDivide.Remove(0, partLength);
                    }

                    input.RemoveAt(int.Parse(currentInput[1]));
                    input.InsertRange(int.Parse(currentInput[1]), temp);
                }

            }
            Console.WriteLine(string.Join(" ", input));
        }

    }
}
