using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfOperation = int.Parse(Console.ReadLine());

            Stack<int> stackInt = new Stack<int>();

            for (int i = 0; i < numOfOperation; i++)
            {
                int[] operations = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (operations[0] == 1)
                {
                    stackInt.Push(operations[1]);
                }
                else if (operations[0] == 2 && stackInt.Count > 0)
                {
                    stackInt.Pop();
                }
                else if (operations[0] == 3 && stackInt.Count > 0)
                {
                    Console.WriteLine(stackInt.Max());
                }
                else if (operations[0] == 4 && stackInt.Count > 0)
                {
                    Console.WriteLine(stackInt.Min());
                }
            }
            Console.WriteLine(string.Join(", ",stackInt));
        }
    }
}
