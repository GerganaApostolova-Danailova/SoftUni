using System;
using System.Linq;

namespace _02._Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                int element = int.Parse(Console.ReadLine());
                arr[i] = element;
            }

            Console.WriteLine(string.Join(" ", arr.Reverse()));

        }
    }
}
