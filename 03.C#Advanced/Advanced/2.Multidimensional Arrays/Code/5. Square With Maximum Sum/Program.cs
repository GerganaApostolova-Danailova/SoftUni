using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;
using System;

namespace _5._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowColMatrix = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[rowColMatrix[0], rowColMatrix[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }

            }

            int maxSum = int.MinValue;
            int selectedRow = -1; 
            int selectedCol = -1;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                int sum = 0;

                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    sum += matrix[row, col] + matrix[row, col + 1]
                        + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        selectedRow = row;
                        selectedCol = col;
                        sum = 0;
                        
                    }
                    sum = 0;
                }
            }

            Console.WriteLine($"{matrix[selectedRow, selectedCol]} {matrix[selectedRow, selectedCol+1]}");
            Console.WriteLine($"{matrix[selectedRow+1, selectedCol]} {matrix[selectedRow+1, selectedCol+1]}");
            Console.WriteLine(maxSum);
        }
    }
}
