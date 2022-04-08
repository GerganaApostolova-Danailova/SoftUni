using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> stack = new Stack<int>(input.Length);

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }

                if (input[i] == ')')
                {
                    int start = stack.Pop();
                    Console.WriteLine(input.Substring(start, i - start + 1));
                }
            }
        }
    }
}
