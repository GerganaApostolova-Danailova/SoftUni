using System;
using System.Linq;
using System.Collections.Generic;

namespace One
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputMales = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x=> x > 0)
                .Where(x=>x % 25 != 0)
                .ToList();

            List<int> inputFemales = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .Where(x => x > 0)
               .Where(x => x % 25 != 0)
               .ToList();

            Stack<int> males = new Stack<int>(inputMales);
            Queue<int> females = new Queue<int>(inputFemales);

            int matches = 0;

            while (males.Count > 0 && females.Count > 0)
            {
                int currentMale = males.Pop();
                int currentFemale = females.Dequeue();

                if (currentMale == currentFemale)
                {
                    matches++;
                }
                else
                {
                    if (currentMale - 2 > 0)
                    {
                    currentMale -= 2;
                    males.Push(currentMale);
                    }
                }
            }

            Console.WriteLine($"Matches: {matches}");

            if (males.Count > 0)
            {
                Console.WriteLine($"Males left: {string.Join(", ", males)}");
            }
            else
            {
                Console.WriteLine($"Males left: none");
            }

            if (females.Count > 0)
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }
    }
}
