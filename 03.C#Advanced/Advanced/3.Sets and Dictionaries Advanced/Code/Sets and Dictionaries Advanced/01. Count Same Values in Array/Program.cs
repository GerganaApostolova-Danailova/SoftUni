using System;
using System.Collections.Generic;
using System.Linq;


namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> dict = new Dictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!dict.ContainsKey(numbers[i]))
                {
                    dict.Add(numbers[i], 0);
                }
                dict[numbers[i]]++;
            }

            foreach (var number in dict)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
