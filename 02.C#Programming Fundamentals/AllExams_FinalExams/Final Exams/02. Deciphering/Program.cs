using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;


namespace _02._Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] replaced = Console.ReadLine()
                .Split();

            string output = string.Empty;

            foreach (var ch in input)
            {
                if (input.Contains(", ") || ch >= 100 && ch <= 122 || ch == '|' || ch == '#' || ch == ',' || ch == ' ')
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("This is not the book you are looking for.");
                    return;
                }
            }

            foreach (char item in input)
            {
                output += (char)(item - 3);
            }

            string r1 = replaced[0];
            string r2 = replaced[1];

            output = output.Replace(r1, r2);

            Console.WriteLine(output);
        }
    }
}





