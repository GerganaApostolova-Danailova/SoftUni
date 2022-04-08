using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _1._Sum_Matrix_Elements
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
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sum += matrix[row,col];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);

        }
    }
}
