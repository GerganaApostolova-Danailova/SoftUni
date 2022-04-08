using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

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
                else //if (operation[0] == "Insert")
                {
                    int number = int.Parse(operation[1]);
                    int index = int.Parse(operation[2]);

                    input.Insert(index, number);
                }
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
