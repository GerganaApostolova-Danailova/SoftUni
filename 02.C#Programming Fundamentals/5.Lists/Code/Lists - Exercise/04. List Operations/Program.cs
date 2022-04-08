using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
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

                if (command == "End")
                {
                    break;
                }

                string[] currentInput = command.Split();

                if (currentInput[0] == "Add")
                {
                    int numberToAdd = int.Parse(currentInput[1]);

                    input.Add(numberToAdd);

                }
                else if (currentInput[0] == "Insert")
                {
                    int numberToInsert = int.Parse(currentInput[1]);
                    int positionToInsert = int.Parse(currentInput[2]);

                    if (positionToInsert < 0 || positionToInsert >= input.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {

                        input.Insert(positionToInsert, numberToInsert);
                    }

                }
                else if (currentInput[0] == "Remove")
                {
                    int numberToRemuve = int.Parse(currentInput[1]);

                    if (numberToRemuve < 0 || numberToRemuve >= input.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        input.RemoveAt(numberToRemuve);
                    }

                }
                else if (currentInput[0] == "Shift" && currentInput[1] == "left")
                {
                    int numberToRotation = int.Parse(currentInput[2]);


                    for (int i = 0; i < numberToRotation; i++)
                    {
                        input.Add(input[0]);
                        input.RemoveAt(0);
                    }

                    //for (int i = 0; i < numberToRotation; i++)
                    //{
                    //    int firstNumber = input[0];

                    //    for (int j = 0; j < input.Count - 1; j++)
                    //    {
                    //        input[j] = input[j + 1];
                    //    }

                    //    input[input.Count - 1] = firstNumber;
                    //}

                }
                else if (currentInput[0] == "Shift" && currentInput[1] == "right")
                {
                    int numberToRotation = int.Parse(currentInput[2]);

                    for (int i = 0; i < numberToRotation; i++)
                    {
                        input.Insert(0, input[input.Count - 1]);
                        input.RemoveAt(input.Count - 1);
                    }
                    //for (int i = input.Count - 1; i > numberToRotation; i--)
                    //{
                    //    int lastNumber = input[input.Count - 1];

                    //    for (int j = input.Count - 1; j > 0; j--)
                    //    {
                    //        input[j] = input[j - 1];
                    //    }

                    //    input[0] = lastNumber;
                    //}
                }

            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
