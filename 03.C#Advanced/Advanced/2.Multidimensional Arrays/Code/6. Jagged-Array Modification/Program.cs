using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsOfMatrix = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rowsOfMatrix][];

            for (int row = 0; row < rowsOfMatrix; row++)
            {
                int[] cols = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                matrix[row] = cols;
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                string[] command = line
                    .Split();

                string operation = command[0];
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (row < 0 || row >= matrix.Length || col < 0 || col >= matrix[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (operation == "Add")
                {
                    matrix[row][col] += value;
                }
                else if (operation == "Subtract")
                {
                    matrix[row][col] -= value;
                }
            }

            foreach (int[] row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
