using System;
using System.Collections.Generic;

namespace _06._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<char> result = new List<char>();


            for (int i = 0; i < input.Length - 1; i++)
            {
                if (i == 0)
                {
                    result.Add(input[0]);
                }
                if (input[i] != input[i + 1])
                {
                    result.Add(input[i + 1]);
                }
                else
                {
                    continue;
                }

            }



            Console.WriteLine(string.Join("", result));
        }
    }
}
