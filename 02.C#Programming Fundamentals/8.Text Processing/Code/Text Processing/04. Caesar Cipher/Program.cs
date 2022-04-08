using System;
using System.Collections.Generic;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<char> result = new List<char>();

            int letter = 0;

            foreach (var word in input)
            {

                letter = word + 3;
                //letter = letter.ToString;

                result.Add((char)letter);

            }

            


            Console.WriteLine(string.Join("",result));
        }
    }
}
