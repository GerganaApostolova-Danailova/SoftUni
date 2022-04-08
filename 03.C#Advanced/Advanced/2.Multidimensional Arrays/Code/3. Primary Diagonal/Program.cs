using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] sqereMatrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < sqereMatrix.GetLength(0); row++)
            {
                int[] valieOfRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < sqereMatrix.GetLength(1); col++)
                {
                    sqereMatrix[row, col] = valieOfRow[col];
                }
            }
            int sum = 0;

            for (int row = 0; row < sqereMatrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < sqereMatrix.GetLength(1); col++)
                {
                    sum += sqereMatrix[col, col];
                    
                }
                break;
            }
            Console.WriteLine(sum);
        }
    }
}
