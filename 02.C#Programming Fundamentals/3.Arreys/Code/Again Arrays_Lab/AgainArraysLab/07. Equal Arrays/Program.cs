using System;
using System.Linq;

namespace _07._Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] arr2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sum = 0;
            int minindex = int.MaxValue;
            bool isequal = false;

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] == arr2[i])
                {
                    sum += arr1[i];
                    
                }
                else 
                {
                    minindex = i;
                    isequal = true;
                    break;
                }
            }
            if (isequal)
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {minindex} index");
            }
            else
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }

        }
    }
}
