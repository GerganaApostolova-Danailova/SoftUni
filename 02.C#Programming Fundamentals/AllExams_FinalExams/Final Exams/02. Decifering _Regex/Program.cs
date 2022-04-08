using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _02._Decifering__Regex
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] replaced = Console.ReadLine()
                .Split();

            string output = string.Empty;

            string pattern = @"[d-z, |#]";


            if (input.Contains(", "))
            {
                MatchCollection match = Regex.Matches(input, pattern);
                if (true)
                {

                }

                    else
                    {
                        Console.WriteLine("This is not the book you are looking for.");
                        return;
                    }
                
            }
            else
            {
                Console.WriteLine("This is not the book you are looking for.");
                return;
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
