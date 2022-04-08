using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int>input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToList();

            Action<List<int>> printResult = numbs => Console.WriteLine(string.Join(" ",numbs));

            int divisibleNum = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = num => num % divisibleNum == 0;

       var result = input.FindAll(x => !isDivisible(x)).ToList();

            printResult(result);
        }
    }
}
