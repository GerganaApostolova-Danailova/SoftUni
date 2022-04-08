using System;

namespace _7._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            long[][] jaggetArrey = new long[size][];
            int cols = 1;

            for (int i = 0; i < size; i++)
            {
                jaggetArrey[i] = new long[cols];
                jaggetArrey[i][0] = 1;
                jaggetArrey[i][cols - 1] = 1;

                if (cols > 2)
                {
                    long[] previousRow = jaggetArrey[i - 1];

                    for (int j = 1; j < cols - 1; j++)
                    {
                        jaggetArrey[i][j] = previousRow[j] + previousRow[j - 1];
                    }
                }
                cols++;
            }

            foreach (var item in jaggetArrey)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
