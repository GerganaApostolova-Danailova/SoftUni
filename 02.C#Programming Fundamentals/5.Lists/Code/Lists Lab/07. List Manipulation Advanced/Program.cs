using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
              .Split()
              .Select(int.Parse)
              .ToList();

            bool IsChanged = false;

            List<int> print = new List<int>();


            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] currentInput = command.Split();

                if (currentInput[0] == "Add")
                {
                    int numberToAdd = int.Parse(currentInput[1]);

                    input.Add(numberToAdd);
                    IsChanged = true;

                }
                else if (currentInput[0] == "Remove")
                {
                    int numberToRemuve = int.Parse(currentInput[1]);

                    input.Remove(numberToRemuve);
                    IsChanged = true;
                }
                else if (currentInput[0] == "RemoveAt")
                {
                    int numberToRemuveAt = int.Parse(currentInput[1]);

                    input.RemoveAt(numberToRemuveAt);
                    IsChanged = true;
                }
                else if (currentInput[0] == "Insert")
                {
                    int numberToInsert = int.Parse(currentInput[1]);
                    int positionToInsert = int.Parse(currentInput[2]);

                    input.Insert(positionToInsert, numberToInsert);
                    IsChanged = true;
                }
                else if (currentInput[0] == "Contains")
                {
                    int numberToContain = int.Parse(currentInput[1]);
                    bool contains = true;

                    for (int i = 0; i < input.Count; i++)
                    {
                        if (input[i] == numberToContain)
                        {
                            Console.WriteLine("Yes");
                            contains = false;
                            break;
                        }

                    }
                    if (contains)
                    {
                        Console.WriteLine("No such number");
                    }

                }
                else if (currentInput[0] == "PrintEven")
                {

                    for (int i = 0; i < input.Count; i++)
                    {
                        if (input[i] % 2 == 0)
                        {
                            print.Add(input[i]);
                        }
                    }
                    Console.WriteLine(string.Join(" ", print));
                    print.Clear();
                }
                else if (currentInput[0] == "PrintOdd")
                {

                    for (int i = 0; i < input.Count; i++)
                    {
                        if (input[i] % 2 == 1)
                        {
                            print.Add(input[i]);
                        }
                    }
                    Console.WriteLine(string.Join(" ", print));
                    print.Clear();
                }
                else if (currentInput[0] == "GetSum")
                {
                    int sum = 0;
                    for (int i = 0; i < input.Count; i++)
                    {
                        sum += input[i];

                    }
                    Console.WriteLine(sum);
                }
                else if (currentInput[0] == "Filter")
                {
                    int numberToFilter = int.Parse(currentInput[2]);



                    if (currentInput[1] == "<")
                    {

                        for (int i = 0; i < input.Count; i++)
                        {
                            if (input[i] < numberToFilter)
                            {
                                print.Add(input[i]);
                            }

                        }
                        Console.WriteLine(string.Join(" ", print));
                        print.Clear();
                    }
                    else if (currentInput[1] == ">")
                    {

                        for (int i = 0; i < input.Count; i++)
                        {
                            if (input[i] > numberToFilter)
                            {
                                print.Add(input[i]);
                            }

                        }
                        Console.WriteLine(string.Join(" ", print));
                        print.Clear();
                    }
                    else if (currentInput[1] == ">=")
                    {

                        for (int i = 0; i < input.Count; i++)
                        {
                            if (input[i] >= numberToFilter)
                            {
                                print.Add(input[i]);
                            }

                        }
                        Console.WriteLine(string.Join(" ", print));
                        print.Clear();
                    }
                    else if (currentInput[1] == "<=")
                    {

                        for (int i = 0; i < input.Count; i++)
                        {
                            if (input[i] <= numberToFilter)
                            {
                                print.Add(input[i]);
                            }

                        }
                        Console.WriteLine(string.Join(" ", print));
                        print.Clear();
                    }

                }
            }
            if (IsChanged)
            {
                Console.WriteLine(string.Join(" ", input));
            }

        }

    }
}

