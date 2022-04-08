using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();

            

            input.Reverse();

            input.RemoveAll(i => i < 0);

            if (input.Count == 0)
            {
                Console.WriteLine("empty");
                return;
            }

            Console.WriteLine(string.Join(" ", input));

        }
    }
}
