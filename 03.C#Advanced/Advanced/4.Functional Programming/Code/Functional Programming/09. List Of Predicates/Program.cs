using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Distinct()
                .ToArray();

            List<int> numbers = new List<int>();

            for (int i = 1; i <= N; i++)
            {
                bool isT = true;

                foreach (var item in dividers)
                {
                    Predicate<int> isDevide = x => i % x == 0;

                    if (!isDevide(item))
                    {
                        isT = false;
                        break;
                    }
                    
                }
                if (isT)
                {
                    numbers.Add(i);
                }
            }
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
