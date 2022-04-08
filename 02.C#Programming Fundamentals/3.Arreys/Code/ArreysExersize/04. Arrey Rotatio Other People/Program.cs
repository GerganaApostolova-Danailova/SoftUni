using System;

namespace _04._Arrey_Rotatio_Other_People
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();  // 1 2 3 4
            int rotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotations; i++)
            {
                int firstElemet = array[0];  // 1
                for (int j = 0; j < array.Length - 1; j++)
                {
                    array[j] = array[j + 1];  // 2 3 4 4
                }
                array[array.Length - 1] = firstElemet; // 2 3 4 1

            }
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
