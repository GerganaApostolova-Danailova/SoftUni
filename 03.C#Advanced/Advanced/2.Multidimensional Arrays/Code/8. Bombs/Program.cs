using System;

using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

using System.Globalization;
using System.Text.RegularExpressions;

namespace _8._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowOfBombAndcolOfBomb = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rowOfBombAndcolOfBomb, rowOfBombAndcolOfBomb];

            for (int rowOfBomb = 0; rowOfBomb < matrix.GetLength(0); rowOfBomb++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int colOfBomb = 0; colOfBomb < matrix.GetLength(1); colOfBomb++)
                {
                    matrix[rowOfBomb, colOfBomb] = input[colOfBomb];
                }
            }

            string[] line = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < line.Length; i++)
            {
                string[] cordinates = line[i]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);

                int rowOfBomb = int.Parse(cordinates[0]);
                int colOfBomb = int.Parse(cordinates[1]);



                if (matrix[rowOfBomb, colOfBomb] > 0 && isInside(matrix, rowOfBomb - 1, colOfBomb) && matrix[rowOfBomb - 1, colOfBomb] > 0)
                {
                    matrix[rowOfBomb - 1, colOfBomb] -= matrix[rowOfBomb, colOfBomb];
                }
                if (matrix[rowOfBomb, colOfBomb] > 0 && isInside(matrix, rowOfBomb + 1, colOfBomb) && matrix[rowOfBomb + 1, colOfBomb] > 0)
                {
                    matrix[rowOfBomb + 1, colOfBomb] -= matrix[rowOfBomb, colOfBomb];
                }
                if (matrix[rowOfBomb, colOfBomb] > 0 && isInside(matrix, rowOfBomb + 1, colOfBomb - 1) && matrix[rowOfBomb + 1, colOfBomb - 1] > 0)
                {
                    matrix[rowOfBomb + 1, colOfBomb - 1] -= matrix[rowOfBomb, colOfBomb];
                }
                if (matrix[rowOfBomb, colOfBomb] > 0 && isInside(matrix, rowOfBomb + 1, colOfBomb + 1) && matrix[rowOfBomb + 1, colOfBomb + 1] > 0)
                {
                    matrix[rowOfBomb + 1, colOfBomb + 1] -= matrix[rowOfBomb, colOfBomb];
                }
                if (matrix[rowOfBomb, colOfBomb] > 0 && isInside(matrix, rowOfBomb, colOfBomb + 1) && matrix[rowOfBomb, colOfBomb + 1] > 0)
                {
                    matrix[rowOfBomb, colOfBomb + 1] -= matrix[rowOfBomb, colOfBomb];
                }
                if (matrix[rowOfBomb, colOfBomb] > 0 && isInside(matrix, rowOfBomb, colOfBomb - 1) && matrix[rowOfBomb, colOfBomb - 1] > 0)
                {
                    matrix[rowOfBomb, colOfBomb - 1] -= matrix[rowOfBomb, colOfBomb];
                }
                if (matrix[rowOfBomb, colOfBomb] > 0 && isInside(matrix, rowOfBomb - 1, colOfBomb - 1) && matrix[rowOfBomb - 1, colOfBomb - 1] > 0)
                {
                    matrix[rowOfBomb - 1, colOfBomb - 1] -= matrix[rowOfBomb, colOfBomb];
                }
                if (matrix[rowOfBomb, colOfBomb] > 0 && isInside(matrix, rowOfBomb - 1, colOfBomb + 1) && matrix[rowOfBomb - 1, colOfBomb + 1] > 0)
                {
                    matrix[rowOfBomb - 1, colOfBomb + 1] -= matrix[rowOfBomb, colOfBomb];
                }
                if (matrix[rowOfBomb, colOfBomb] > 0)
                {
                    matrix[rowOfBomb, colOfBomb] = 0;
                }
            }

            int sum = 0;
            int aliveCells = 0;


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");


            for (int rowOfBomb = 0; rowOfBomb < matrix.GetLength(0); rowOfBomb++)
            {
                for (int colOfBomb = 0; colOfBomb < matrix.GetLength(1); colOfBomb++)
                {
                    Console.Write(matrix[rowOfBomb, colOfBomb] + " ");
                }
                Console.WriteLine();
            }

        }
        private static bool isInside(int[,] matrix, int rowOfBomb, int colOfBomb)
        {
            return rowOfBomb < matrix.GetLength(0) && rowOfBomb >= 0
                 && colOfBomb < matrix.GetLength(1) && colOfBomb >= 0;
        }
    }
}
