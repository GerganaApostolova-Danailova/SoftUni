using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Equal_Arrays_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] arr2 = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int sum = 0;
            // int diff = 0;

            for (int i = 0; i < arr1.Length; i++)
            {


                sum += arr1[i];

                if (arr1[i] != arr2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");

                   // diff = 1;
                    return;

                }



            }

            //if (diff == 0)
            ///{
                sum = arr1.Sum();
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            ///}
        }
    }
}
