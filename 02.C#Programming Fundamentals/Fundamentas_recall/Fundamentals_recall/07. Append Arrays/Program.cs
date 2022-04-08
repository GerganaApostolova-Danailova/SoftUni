using System;
using System.Collections.Generic;
using System.Linq;


namespace _07._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<int> newList = new List<int>();
            List<int> list = new List<int>();



            for (int i = input.Count - 1; i >= 0; i--)
            {
                newList = input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                foreach (var item in newList)
                {
                    list.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}

