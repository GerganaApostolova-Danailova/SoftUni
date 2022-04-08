using System;
using System.Linq;

namespace _1_Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int[] arr = new int[num];

            for (int i = 0; i < num; i++)
            {
                int currentItem = int.Parse(Console.ReadLine());

                arr[i] = currentItem;
            }

            Console.WriteLine(string.Join(' ',arr));
            Console.WriteLine(arr.Sum());
        }
    }
}
