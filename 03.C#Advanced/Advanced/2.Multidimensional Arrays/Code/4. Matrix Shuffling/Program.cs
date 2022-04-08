using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowColNUmber = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();


            string[,] matrix = new string[rowColNUmber[0], rowColNUmber[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] inputRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }


            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                string[] command = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string operation = command[0];
                int row1 = int.Parse(command[1]);
                int col1 = int.Parse(command[2]);
                int row2 = int.Parse(command[3]);
                int col2 = int.Parse(command[4]);

                string help = " ";

                if (operation == "swap" && isValid(matrix, row1, col1, row2, col2))
                {
                    help = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = help;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }

        }

        private static bool isValid(string[,] matrix, int row1, int col1, int row2, int col2)
        {
            return row1 < matrix.GetLength(0) && row1 >= 0
                && row2 < matrix.GetLength(0) && row2 >= 0
                && col1 < matrix.GetLength(1) && col1 >= 0
                && col2 < matrix.GetLength(1) && col2 >= 0;
        }
    }
}
