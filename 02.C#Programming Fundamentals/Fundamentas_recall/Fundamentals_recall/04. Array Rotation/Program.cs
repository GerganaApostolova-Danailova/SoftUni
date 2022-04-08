using System;
using System.Linq;

namespace _08._Magic_Sum 
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int magicSum = int.Parse(Console.ReadLine());

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] + arr[i+1] == magicSum)
                {
                    Console.WriteLine($"{arr[i]} {arr[i+1]}");
                }
            }
        }
    }
}
