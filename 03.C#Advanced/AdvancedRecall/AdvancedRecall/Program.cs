using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedRecall
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            foreach (var ch in input)
            {
                stack.Push(ch);
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }

        }
    }
}
