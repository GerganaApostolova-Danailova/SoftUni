using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(nums);

            while (true)
            {
                string[] input = Console.ReadLine()
                        .ToLower()
                        .Split();

                if (input[0] == "end")
                {
                    break;
                }
                else if (input[0] == "add")
                {
                    int addNumberOne = int.Parse(input[1]);
                    int addNumberTwo = int.Parse(input[2]);

                    stack.Push(addNumberOne);
                    stack.Push(addNumberTwo);
                }
                else if (input[0] == "remove")
                {
                    int numberToRemove = int.Parse(input[1]);

                    if (stack.Count >= numberToRemove)
                    {
                        for (int i = 0; i < numberToRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }

            while (stack.Count > 1)
            {
                int furstNum = stack.Pop();
                int secondNum = stack.Pop();

                stack.Push(furstNum + secondNum);
            }

            Console.WriteLine($"Sum: {stack.Peek()}");
        }
    }
}
