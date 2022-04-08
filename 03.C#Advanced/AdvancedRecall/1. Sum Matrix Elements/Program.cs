using System;
using System.Linq;
using System.Collections.Generic;

namespace _1._Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numRowCol = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[numRowCol[0], numRowCol[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] matrixRow = Console.ReadLine()
                    .Split(", ")
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
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sum += matrix[row, col];
                }
            }

            Console.WriteLine(numRowCol[0]);
            Console.WriteLine(numRowCol[1]);
            Console.WriteLine(sum);
        }
    }
}
