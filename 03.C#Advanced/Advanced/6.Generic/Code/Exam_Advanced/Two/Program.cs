using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Two
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            // input = input.Remove(input.Length - 1);

            int numOfMatrix = int.Parse(Console.ReadLine());

            char[][] matrix = new char[numOfMatrix][];

            int rowOfP = 0;
            int colOfP = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .ToCharArray();

                matrix[row] = new char[currentRow.Length];


                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = currentRow[col];

                    if (matrix[row][col] == 'P')
                    {
                        rowOfP = row;
                        colOfP = col;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                if (command == "up")
                {
                    if (isInside(matrix, rowOfP - 1, colOfP))
                    {

                        if (char.IsLetter(matrix[rowOfP - 1][colOfP]))
                        {
                            input += matrix[rowOfP - 1][colOfP];
                        }
                        matrix[rowOfP - 1][colOfP] = 'P';
                        matrix[rowOfP][colOfP] = '-';
                        rowOfP--;
                    }
                    else
                    {
                        if (input.Length > 0)
                        {
                            input = input.Remove(input.Length - 1);
                        }
                    }
                }
                else if (command == "down")
                {
                    if (isInside(matrix, rowOfP + 1, colOfP))
                    {

                        if (char.IsLetter(matrix[rowOfP + 1][colOfP]))
                        {
                            input += matrix[rowOfP + 1][colOfP];
                        }
                        matrix[rowOfP + 1][colOfP] = 'P';
                        matrix[rowOfP][colOfP] = '-';
                        rowOfP++;
                    }
                    else
                    {
                        if (input.Length > 0)
                        {
                            input = input.Remove(input.Length - 1);
                        }
                    }
                }
                else if (command == "right")
                {
                    if (isInside(matrix, rowOfP, colOfP + 1))
                    {
                        if (char.IsLetter(matrix[rowOfP][colOfP + 1]))
                        {
                            input += matrix[rowOfP][colOfP + 1];
                        }
                        matrix[rowOfP][colOfP + 1] = 'P';
                        matrix[rowOfP][colOfP] = '-';
                        colOfP++;
                    }
                    else
                    {
                        if (input.Length > 0)
                        {
                            input = input.Remove(input.Length - 1);
                        }
                    }
                }
                else if (command == "left")
                {
                    if (isInside(matrix, rowOfP, colOfP - 1))
                    {
                        if (char.IsLetter(matrix[rowOfP][colOfP - 1]))
                        {
                            input += matrix[rowOfP][colOfP - 1];
                        }
                        matrix[rowOfP][colOfP - 1] = 'P';
                        matrix[rowOfP][colOfP] = '-';
                        colOfP--;
                    }
                    else
                    {
                        if (input.Length > 0)
                        {
                            input = input.Remove(input.Length - 1);
                        }
                    }
                }
            }

            Console.WriteLine(input);

            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(matrix[row]);
            }

        }
        private static bool isInside(char[][] matrix, int row, int col)
        {
            return row < matrix.Length && row >= 0
                 && col < matrix[row].Length && col >= 0;
        }
    }
}
