using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> output = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!output.ContainsKey(word))
                {
                    output[word] = new List<string>();
                }

                output[word].Add(synonym);
            }

            foreach (var word in output)
            {
                Console.WriteLine($"{word.Key} - {string.Join(", ", word.Value)}");
            }
        }
    }
}
