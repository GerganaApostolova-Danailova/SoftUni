using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
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

            if (currentInput[0] == "Delete")
            {
                int numberToDelite = int.Parse(currentInput[1]);

                input.RemoveAll(x => x == numberToDelite);

            }            
            else if (currentInput[0] == "Insert")
            {
                int numberToInsert = int.Parse(currentInput[1]);
                int positionToInsert = int.Parse(currentInput[2]);

                input.Insert(positionToInsert, numberToInsert);
            }

        }
        Console.WriteLine(string.Join(" ", input));
        }
    }
}
