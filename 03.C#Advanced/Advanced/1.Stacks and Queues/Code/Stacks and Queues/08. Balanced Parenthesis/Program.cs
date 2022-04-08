using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> parenties = new Stack<char>();

            char[] input = Console.ReadLine()
                .ToCharArray();

            char[] openParenties = new char[] { '(', '{', '[' };

            bool isValid = true;


            foreach (var item in input)
            {
                if (openParenties.Contains(item))
                {
                    parenties.Push(item);
                    continue;
                }
                if (parenties.Count() == 0)
                {
                    isValid = false;
                    break;
                }
                if (parenties.Peek() == '(' && item == ')')
                {
                    parenties.Pop();
                }
                else if (parenties.Peek() == '[' && item == ']')
                {
                    parenties.Pop();
                }
                else if (parenties.Peek() == '{' && item == '}')
                {
                    parenties.Pop();
                }
                else
                {
                    isValid = false;
                    break;
                }
            }
            if (isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
