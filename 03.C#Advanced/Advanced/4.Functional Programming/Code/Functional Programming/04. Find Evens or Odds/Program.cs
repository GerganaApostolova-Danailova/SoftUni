using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEvenPredicate = num => num % 2 == 0;

            Action<List<int>> printResult = nums => Console.WriteLine(string.Join(" ",nums));

            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int startNum = input[0];
            int endNum = input[1];

            List<int> numbers = new List<int>();

            for (int i = startNum; i <= endNum; i++)
            {
                numbers.Add(i);
            }

            string command = Console.ReadLine();

            List<int> result = new List<int>();

            if (command == "even")
            {
                result = numbers.FindAll(x => isEvenPredicate(x));
            }
            else
            {
                result = numbers.FindAll(x => !isEvenPredicate(x));
            }

            printResult(result);
        }
    }
}
