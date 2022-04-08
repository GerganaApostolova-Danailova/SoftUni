using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _02._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] word = Console.ReadLine()
                .Split();

            Random rnm = new Random();

            for (int i = 0; i < word.Length; i++)
            {
                int randomIndex = rnm.Next(0, word.Length);

                var element = word[i];
                var randumElement = word[randomIndex];

                word[randomIndex] = element;
                word[i] = randumElement;
            }

            foreach (var item in word)
            {
                Console.WriteLine(item);
            }
        }
    }
}
