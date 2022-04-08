using System;
using System.Linq;
using System.Collections.Generic;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                bool isPolidrome = IsPolidromOrNot(input);
                Console.WriteLine(isPolidrome.ToString().ToLower());
                input = Console.ReadLine();
            }

        }

        static bool IsPolidromOrNot(string input)
        {
            char[] cArray = input.ToCharArray();
            string reverse = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }

            return input == reverse;
        }
    }
}
