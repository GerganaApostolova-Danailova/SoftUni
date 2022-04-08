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

            List<int> originalList = input;

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] operation = command
                    .Split()
                    .ToArray();

                if (operation[0] == "Add")
                {
                    int number = int.Parse(operation[1]);

                    input.Add(number);
                }
                else if (operation[0] == "Remove")
                {
                    int number = int.Parse(operation[1]);

                    input.Remove(number);
                }
                else if (operation[0] == "RemoveAt")
                {
                    int number = int.Parse(operation[1]);

                    input.RemoveAt(number);
                }
                else if (operation[0] == "Insert")
                {
                    int number = int.Parse(operation[1]);
                    int index = int.Parse(operation[2]);

                    input.Insert(index, number);
                }
                else if (operation[0] == "Contains")
                {
                    int number = int.Parse(operation[1]);

                    if (input.Contains(number))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (operation[0] == "PrintEven")
                {
                    PrintEvenNumber(input);
                }
                else if (operation[0] == "PrintOdd")
                {
                    PrintOddNumber(input);
                }
                else if (operation[0] == "GetSum")
                {
                    PrintSum(input);
                }
                else if (operation[0] == "Filter")
                {
                    string condition = operation[1];
                    int number = int.Parse(operation[2]);

                    if (condition == ">")
                    {
                        List<int> graterList = input.Where(x => x > number).ToList();
                        Console.WriteLine(string.Join(" ", graterList));
                    }
                    else if (condition == "<")
                    {
                        List<int> smallerList = input.Where(x => x < number).ToList();
                        Console.WriteLine(string.Join(" ", smallerList));
                    }
                    else if (condition == ">=")
                    {
                        List<int> graterAndEqualList = input.Where(x => x >= number).ToList();
                        Console.WriteLine(string.Join(" ", graterAndEqualList));
                    }
                    else if (condition == "<=")
                    {
                        List<int> smallerAndEqualList = input.Where(x => x <= number).ToList();
                        Console.WriteLine(string.Join(" ", smallerAndEqualList));
                    }
                }
            }

            if (originalList != input)
            {
                Console.WriteLine(string.Join(" ", input));
            }


        }

        private static void PrintSum(List<int> input)
        {
            Console.WriteLine(input.Sum());
        }

        static void PrintEvenNumber(List<int> input)
        {
            List<int> evenList = input.Where(x => (x % 2) == 0).ToList();
            Console.WriteLine(string.Join(" ", evenList));
        }
        static void PrintOddNumber(List<int> input)
        {
            List<int> oddList = input.Where(x => (x % 2) != 0).ToList();
            Console.WriteLine(string.Join(" ", oddList));
        }
    }
}
