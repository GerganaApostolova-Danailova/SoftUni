using System;
using System.Linq;

namespace _04._Array_Rotation_Right_To_Left
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

            for (int i = 0; i < n; i++)
            {


                if (n > 0)
                {
                    arr2[n-1-i] = arr[arr.Length -1 -i];
                    arr2[n+i] = arr[i];
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
