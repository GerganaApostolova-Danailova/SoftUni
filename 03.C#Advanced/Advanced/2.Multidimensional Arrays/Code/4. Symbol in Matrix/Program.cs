using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] sqereMatrix = new char[matrixSize, matrixSize];

            for (int row = 0; row < sqereMatrix.GetLength(0); row++)
            {
                char[] valieOfRow = Console.ReadLine()
                    .ToCharArray();
                    

                for (int col = 0; col < sqereMatrix.GetLength(1); col++)
                {
                    sqereMatrix[row, col] = valieOfRow[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());


            for (int row = 0; row < sqereMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < sqereMatrix.GetLength(1); col++)
                {
                    if (sqereMatrix[row,col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}
