using System;
using System.Collections.Generic;

namespace _04._List_of_Products
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> result = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string vegetable = Console.ReadLine();

                result.Add(vegetable);

            }
            result.Sort();

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"{i}.{result[i-1]}");
            }
        }
    }
}
