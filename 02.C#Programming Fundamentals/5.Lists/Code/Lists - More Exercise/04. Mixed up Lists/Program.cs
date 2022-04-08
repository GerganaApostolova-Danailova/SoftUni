using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Mixed_up_Lists
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

            List<int> result = new List<int>();

            if (arr1.Length > arr2.Length)
            {
                bool right = false;
                int num1 = arr1[arr1.Length - 1];
                int num2 = arr1[arr1.Length - 2];

               if (num2 > num1)
                {
                    int temp = num1;
                    num1 = num2;
                    num2 = temp;
                }

                for (int i = 0; i < arr1.Length -2; i++)
                {
                    result.Add(arr1[i]);
                    result.Add(arr2[arr2.Length-1 - i]);
                }
                result.RemoveAll(x => x >= num1);
                result.RemoveAll(x => x <= num2);
                result.Sort();
            }
            else if (arr1.Length < arr2.Length)
            {
                
                int num1 = arr2[0];
                int num2 = arr2[1];

                if (num2 > num1)
                {
                    int temp = num1;
                    num1 = num2;
                    num2 = temp;
                }

                for (int i = 0; i < arr2.Length - 2; i++)
                {
                    result.Add(arr1[i]);
                    result.Add(arr2[arr2.Length - 1 - i]);
                }
                result.RemoveAll(x => x >= num1);
                result.RemoveAll(x => x <= num2);
                result.Sort();
            }


            Console.WriteLine(string.Join(" ",result));

        }
    }
}
