using System;
using System.Collections.Generic;

namespace _05._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();


            string text = string.Empty;
            string ch = string.Empty;

            bool resultDigit;
            bool resultLetter;
            bool resultChar;

            List<char> digit = new List<char>();

            foreach (char letter in input)
            {
                resultDigit = Char.IsDigit(letter);
                resultLetter = char.IsLetter(letter);
                resultChar = char.IsLetterOrDigit(letter);


                if (resultDigit)
                {
                    digit.Add(letter);
                }
                if (resultLetter)
                {
                    text += letter;
                }
                else if (!resultChar)
                {
                    ch += letter;
                }
            }
            Console.WriteLine(string.Join("", digit));
            Console.WriteLine(text);
            Console.WriteLine($"{ch}");
        }
    }
}
