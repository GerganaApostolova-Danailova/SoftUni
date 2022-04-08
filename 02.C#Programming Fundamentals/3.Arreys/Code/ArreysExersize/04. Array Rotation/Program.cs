using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] arr2 = new int[arr.Length];

            int n = int.Parse(Console.ReadLine());

            int lastElement = arr[arr.Length - 1];

            for (int i = 0; i < n; i++)
            {

                if (n > arr.Length)
                {
                    n = n - arr.Length;
                }

                if (n > 0)
                {

                    arr2[arr2.Length - n + i] = arr[i];
                    arr2[i] = arr[n + i];
                    arr2[n] = lastElement;

                }
                else
                {
                    arr2[i] = arr[i];
                }

            }
            



            Console.Write(string.Join(" ", arr2));
        }


    }
}
