using System;
using System.Linq;
using System.Collections.Generic;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int[,] matrix = new int[num, num];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] matrixRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = matrixRow[col];
                }
            }

            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sum += matrix[row, row];
            }

            Console.WriteLine(sum);
        }
    }
}
