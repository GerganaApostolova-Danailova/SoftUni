using System;
using System.Linq;
using System.Collections.Generic;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(input);

            string command = Console.ReadLine().ToLower();


            while (command != "end")
            {
                string[] operationsAndNumber = command.Split();

                string @operator = operationsAndNumber[0].ToLower();

                if (@operator == "add")
                {
                    int num1 = int.Parse(operationsAndNumber[1]);
                    int num2 = int.Parse(operationsAndNumber[2]);

                    stack.Push(num1);
                    stack.Push(num2);
                }
                else if (@operator == "remove")
                {
                    int numToRemove = int.Parse(operationsAndNumber[1]);

                    if (stack.Count >= numToRemove)
                    {
                        for (int i = 0; i < numToRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

                command = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
