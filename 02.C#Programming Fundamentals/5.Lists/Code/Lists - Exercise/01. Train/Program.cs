using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();

            int capasityOfOneVagon = int.Parse(Console.ReadLine());


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
                else
                {
                    int passengers = int.Parse(currentInput[0]);

                    for (int i = 0; i < input.Count; i++)
                    {
                        if (input[i] + passengers <= capasityOfOneVagon)
                        {
                            input[i] += passengers;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
