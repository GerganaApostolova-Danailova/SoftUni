using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowColNUmber = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            

            char[,] matrix = new char[rowColNUmber[0],rowColNUmber[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] inputRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }
            char currenChar = ' ';
            bool isEqual = false;
            int count = 1;
            bool haveOneSAme = false;


            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (haveOneSAme && isTwoOfTwo(matrix, row,col) && currenChar == matrix[row, col])
                    {
                        isEqual = true;
                        count++;
                    }
                    if (isTwoOfTwo(matrix, row, col))
                    {
                        currenChar = matrix[row,col];
                        haveOneSAme = true;
                        isEqual = true;
                    }
                    
                }
            }
            if (isEqual)
            {
                Console.WriteLine(count);
            }
            else
            {
                Console.WriteLine(0);
            }
        }

        private static bool isTwoOfTwo(char[,] matrix, int row, int col)
        {
           return matrix[row, col] == matrix[row, col + 1]
                        && matrix[row + 1, col] == matrix[row + 1, col + 1]
                        && matrix[row, col] == matrix[row + 1, col + 1];
        }
    }
}
