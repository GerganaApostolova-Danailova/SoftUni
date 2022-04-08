using System;
using System.Linq;

namespace _08._Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] arr2 = new int[arr.Length-1];

            if (arr.Length == 1)
            {
                Console.WriteLine(arr[0]);
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr2.Length-i; j++)
                {
                    arr2[j] = arr[j] + arr[j + 1];
                }
            arr = arr2;                
            }
            Console.WriteLine(arr2[0]);
        }
    }
}
