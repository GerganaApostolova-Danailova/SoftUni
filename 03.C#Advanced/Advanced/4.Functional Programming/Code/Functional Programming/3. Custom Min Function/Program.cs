using System;
using System.Linq;

namespace _3._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minFunction = inputNumbers =>
            {
                int minVAlue = int.MaxValue;
                foreach (var item in inputNumbers)
                {
                    if (item < minVAlue)
                    {
                        minVAlue = item;
                    }
                }
                return minVAlue;

            };


            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int result = minFunction(numbers);

            Console.WriteLine(result);
                
        }
    }
}
