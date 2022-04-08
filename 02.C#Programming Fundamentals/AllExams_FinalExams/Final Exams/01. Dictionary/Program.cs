using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;


namespace _01._Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] wordDesctription = Console.ReadLine()
                .Split(" | ");

            List<string> inputs = Console.ReadLine()
                .Split(" | ")
                .Select(x => x)
                .ToList();


            string command = Console.ReadLine();

            SortedDictionary<string, List<string>> wordDictionary = new SortedDictionary<string, List<string>>();

            List<string> output = new List<string>();

            foreach (var part in wordDesctription)
            {
                string[] currentWord = part
                    .Split(": ");

                string word = currentWord[0];
                string description = currentWord[1];

                if (!wordDictionary.ContainsKey(word))
                {

                    wordDictionary.Add(word, new List<string>());

                }
                if (!wordDictionary[word].Contains(description))
                {
                    wordDictionary[word].Add(description);
                }
            }

            bool isEqual = true;

            for (int i = 0; i < inputs.Count; i++)
            {
                string wordToPrint = inputs[i];

                if (wordDictionary.ContainsKey(wordToPrint))
                {
                    isEqual = false;
                    if (command == "List")
                    {
                        foreach (var item in wordDictionary)
                        {
                            if (item.Key == wordToPrint)
                            {
                                Console.Write(item.Key + " ");

                            }
                        }
                    }
                    else if (command == "End")
                    {
                        foreach (var item in wordDictionary)
                        {
                            if (item.Key == wordToPrint)
                            {
                                Console.WriteLine(item.Key);

                                foreach (var itemInList in item.Value.OrderByDescending(x => x.Length))
                                {
                                    Console.WriteLine($" -{itemInList}");
                                }
                            }
                        }
                    }
                }
                else if(i == inputs.Count-1)
                {
                    if (command == "List" && isEqual)
                    {
                        foreach (var item in wordDictionary)
                        {
                            Console.Write(item.Key + " ");
                            
                        }
                    }
                    
                }
            }
        }
    }
}
