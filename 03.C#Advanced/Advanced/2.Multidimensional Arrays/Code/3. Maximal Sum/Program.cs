using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowColNUmber = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            int[,] matrix = new int[rowColNUmber[0], rowColNUmber[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] inputRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            int sum = 0;
            int maxSum = int.MinValue;
            int currentRow = -1;
            int currentCol = -1;




            for (int row = 0; row < matrix.GetLength(0)-2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-2; col++)
                {
                    sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                        + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                        + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        currentCol = col;
                        currentRow = row;
                        sum = 0;
                    }
                    sum = 0;
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[currentRow,currentCol]} " +
                $"{matrix[currentRow, currentCol+1]} {matrix[currentRow, currentCol+2]}");
            Console.WriteLine($"{matrix[currentRow+1, currentCol]} " +
                $"{matrix[currentRow+1, currentCol + 1]} {matrix[currentRow+1, currentCol + 2]}");
            Console.WriteLine($"{matrix[currentRow+2, currentCol]} " +
                $"{matrix[currentRow+2, currentCol + 1]} {matrix[currentRow+2, currentCol + 2]}");
        }
    }
}
