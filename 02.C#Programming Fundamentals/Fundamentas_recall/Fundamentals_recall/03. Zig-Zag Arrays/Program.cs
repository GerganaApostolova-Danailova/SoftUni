using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr1 = new int[n];
            int[] arr2 = new int[n];

            for (int i = 1; i <= n; i++)
            {
                int[] arrey = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (i % 2 != 0)
                {
                    arr1[i - 1] = arrey[0];
                    arr2[i - 1] = arrey[1];
                }
                else
                {
                    arr2[i - 1] = arrey[0];
                    arr1[i - 1] = arrey[1];
                }

            }

            Console.WriteLine(string.Join(" ", arr1));
            Console.WriteLine(string.Join(" ", arr2));
        }
    }
}
