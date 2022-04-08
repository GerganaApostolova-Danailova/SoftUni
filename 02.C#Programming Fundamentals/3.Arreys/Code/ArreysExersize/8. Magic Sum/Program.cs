using System;
using System.Linq;

namespace _8._Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            int n = int.Parse(Console.ReadLine());

            int value1 = 0;
            int value2 = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == n)
                    {
                        value1 = arr[i];
                        value2 = arr[j];
                        Console.Write($"{value1} {value2}");
                        Console.WriteLine();
                        continue;
                    }
                }
            }
        }
    }
}
