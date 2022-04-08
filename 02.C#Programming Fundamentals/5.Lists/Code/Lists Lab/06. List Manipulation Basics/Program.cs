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

                }
                else if (currentInput[0] == "Remove")
                {
                    int numberToRemuve = int.Parse(currentInput[1]);

                    input.Remove(numberToRemuve);
                }
                else if (currentInput[0] == "RemoveAt")
                {
                    int numberToRemuveAt = int.Parse(currentInput[1]);

                    input.RemoveAt(numberToRemuveAt);
                }
                else if (currentInput[0] == "Insert")
                {
                    int numberToInsert = int.Parse(currentInput[1]);
                    int positionToInsert = int.Parse(currentInput[2]);

                    input.Insert(positionToInsert,numberToInsert);
                }

            }
            Console.WriteLine(string.Join(" ",input));
        }
    }
}
