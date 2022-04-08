using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                .Split();

            Dictionary<char, int> output = new Dictionary<char, int>();


            for (int i = 0; i < text.Length; i++)
            {
                foreach (var ch in text[i])
                {

                    if (output.ContainsKey(ch))
                    {
                        output[ch]++;
                    }
                    else
                    {
                        output.Add(ch, 1);
                    }
                }
            }

            foreach (var item in output)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
