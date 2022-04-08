using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            char[,] matrix = new char[num, num];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string matrixRow = Console.ReadLine();

                char[] charArray = matrixRow.ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = charArray[col];
                }
            }

            char simbol = char.Parse(Console.ReadLine());

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == simbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

                Console.WriteLine($"{simbol} does not occur in the matrix");
        }
    }
}
