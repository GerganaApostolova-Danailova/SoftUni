using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowCol = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            char[,] matrix = new char[rowCol[0], rowCol[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] matrixRow = Console.ReadLine()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = matrixRow[col];
                }
            }

            int count = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1]
                        && matrix[row + 1, col] == matrix[row + 1, col + 1]
                        && matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        count++;
                    }
                }
            }

            if (count > 0)
            {
                Console.WriteLine(count);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
