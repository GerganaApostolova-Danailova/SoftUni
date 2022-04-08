using System;
using System.Linq;
using System.Collections.Generic;


namespace _02._Tron_Racers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            char[,] matrix = new char[num, num];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine()
                    .ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int firstIndexRow = 0;
            int firstIndexCol = 0;


            int secondIndexRow = 0;
            int secondIndexCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'f')
                    {
                        firstIndexRow = row;
                        firstIndexCol = col;
                    }
                    if (matrix[row, col] == 's')
                    {
                        secondIndexRow = row;
                        secondIndexCol = col;
                    }
                }
            }

            while (true)
            {
                string[] move = Console.ReadLine()
                    .Split();

                string moveFirst = move[0];
                string moveSecond = move[1];

                if (moveFirst == "up")
                {
                    if (isInside(matrix, firstIndexRow - 1, firstIndexCol))
                    {
                        if (matrix[firstIndexRow - 1, firstIndexCol] == '*' || matrix[firstIndexRow - 1, firstIndexCol] == 'f')
                        {
                            matrix[firstIndexRow - 1, firstIndexCol] = 'f';

                            firstIndexRow = firstIndexRow - 1;
                            //firstIndexCol = firstIndexCol;
                        }
                        else if (matrix[firstIndexRow - 1, firstIndexCol] == 's')
                        {
                            matrix[firstIndexRow - 1, firstIndexCol] = 'x';
                            break;
                        }
                    }
                    else
                    {
                        if (matrix[num - 1, firstIndexCol] == '*' || matrix[num - 1, firstIndexCol] == 'f')
                        {
                            matrix[num - 1, firstIndexCol] = 'f';

                            firstIndexRow = num - 1;
                            //firstIndexCol = firstIndexCol;
                        }
                        else
                        {
                            matrix[num - 1, firstIndexCol] = 'x';
                            break;
                        }
                    }
                }
                else if (moveFirst == "down")
                {
                    if (isInside(matrix, firstIndexRow + 1, firstIndexCol))
                    {
                        if (matrix[firstIndexRow + 1, firstIndexCol] == '*' || matrix[firstIndexRow + 1, firstIndexCol] == 'f')
                        {
                            matrix[firstIndexRow + 1, firstIndexCol] = 'f';

                            firstIndexRow = firstIndexRow + 1;
                            //firstIndexCol = firstIndexCol;
                        }
                        else if (matrix[firstIndexRow + 1, firstIndexCol] == 's')
                        {
                            matrix[firstIndexRow + 1, firstIndexCol] = 'x';
                            break;
                        }
                    }
                    else
                    {
                        if (matrix[0, firstIndexCol] == '*' || matrix[0, firstIndexCol] == 'f')
                        {
                            matrix[0, firstIndexCol] = 'f';

                            firstIndexRow = 0;
                            //firstIndexCol = firstIndexCol;
                        }
                        else
                        {
                            matrix[0, firstIndexCol] = 'x';
                            break;
                        }
                    }
                }
                else if (moveFirst == "right")
                {
                    if (isInside(matrix, firstIndexRow, firstIndexCol + 1))
                    {
                        if (matrix[firstIndexRow, firstIndexCol + 1] == '*' || matrix[firstIndexRow, firstIndexCol + 1] == 'f')
                        {
                            matrix[firstIndexRow, firstIndexCol + 1] = 'f';

                            //firstIndexRow = firstIndexRow;
                            firstIndexCol = firstIndexCol + 1;
                        }
                        else if (matrix[firstIndexRow, firstIndexCol + 1] == 's')
                        {
                            matrix[firstIndexRow, firstIndexCol + 1] = 'x';
                            break;
                        }
                    }
                    else
                    {
                        if (matrix[firstIndexRow, 0] == '*' || matrix[firstIndexRow, 0] == 'f')
                        {
                            matrix[firstIndexRow, 0] = 'f';

                           // firstIndexRow = firstIndexRow;
                            firstIndexCol = 0;
                        }
                        else
                        {
                            matrix[firstIndexRow, 0] = 'x';
                            break;
                        }
                    }
                }
                else if (moveFirst == "left")
                {
                    if (isInside(matrix, firstIndexRow, firstIndexCol - 1))
                    {
                        if (matrix[firstIndexRow, firstIndexCol - 1] == '*' || matrix[firstIndexRow, firstIndexCol - 1] == 'f')
                        {
                            matrix[firstIndexRow, firstIndexCol - 1] = 'f';

                            //firstIndexRow = firstIndexRow;
                            firstIndexCol = firstIndexCol - 1;
                        }
                        else if (matrix[firstIndexRow, firstIndexCol - 1] == 's')
                        {
                            matrix[firstIndexRow, firstIndexCol - 1] = 'x';
                            break;
                        }
                    }
                    else
                    {
                        if (matrix[firstIndexRow, num -1 ] == '*' || matrix[firstIndexRow, num - 1] == 'f')
                        {
                            matrix[firstIndexRow, num - 1] = 'f';

                            //firstIndexRow = firstIndexRow;
                            firstIndexCol = num - 1;
                        }
                        else
                        {
                            matrix[firstIndexRow, num - 1] = 'x';
                            break;
                        }
                    }
                }
                if (moveSecond == "up")
                {
                    if (isInside(matrix, secondIndexRow - 1, secondIndexCol))
                    {
                        if (matrix[secondIndexRow - 1, secondIndexCol] == '*' || matrix[secondIndexRow - 1, secondIndexCol] == 's')
                        {
                            matrix[secondIndexRow - 1, secondIndexCol] = 's';

                            secondIndexRow = secondIndexRow - 1;
                            //secondIndexCol = secondIndexCol;
                        }
                        else if (matrix[secondIndexRow - 1, secondIndexCol] == 'f')
                        {
                            matrix[secondIndexRow - 1, secondIndexCol] = 'x';
                            break;
                        }
                    }
                    else
                    {
                        if (matrix[num - 1, secondIndexCol] == '*' || matrix[num - 1, secondIndexCol] == 's')
                        {
                            matrix[num - 1, secondIndexCol] = 's';

                            secondIndexRow = num - 1;
                            //secondIndexCol = secondIndexCol;
                        }
                        else
                        {
                            matrix[num - 1, secondIndexCol] = 'x';
                            break;
                        }
                    }
                }
                else if (moveSecond == "down")
                {
                    if (isInside(matrix, secondIndexRow + 1, secondIndexCol))
                    {
                        if (matrix[secondIndexRow + 1, secondIndexCol] == '*' || matrix[secondIndexRow + 1, secondIndexCol] == 's')
                        {
                            matrix[secondIndexRow + 1, secondIndexCol] = 's';

                            secondIndexRow = secondIndexRow + 1;
                           // secondIndexCol = secondIndexCol;
                        }
                        else if (matrix[secondIndexRow + 1, secondIndexCol] == 'f')
                        {
                            matrix[secondIndexRow + 1, secondIndexCol] = 'x';
                            break;
                        }
                    }
                    else
                    {
                        if (matrix[0, secondIndexCol] == '*' || matrix[0, secondIndexCol] == 's')
                        {
                            matrix[0, secondIndexCol] = 's';

                            secondIndexRow = 0;
                            //secondIndexCol = secondIndexCol;
                        }
                        else
                        {
                            matrix[0, secondIndexCol] = 'x';
                            break;
                        }
                    }
                }
                else if (moveSecond == "right")
                {
                    if (isInside(matrix, secondIndexRow, secondIndexCol+1))
                    {
                        if (matrix[secondIndexRow, secondIndexCol + 1] == '*' || matrix[secondIndexRow, secondIndexCol + 1] == 's')
                        {
                            matrix[secondIndexRow, secondIndexCol + 1] = 's';

                            //secondIndexRow = secondIndexRow;
                            secondIndexCol = secondIndexCol +1;
                        }
                        else if (matrix[secondIndexRow, secondIndexCol + 1] == 'f')
                        {
                            matrix[secondIndexRow, secondIndexCol + 1] = 'x';
                            break;
                        }
                    }
                    else
                    {
                        if (matrix[secondIndexRow, 0] == '*' || matrix[secondIndexRow, 0] == 's')
                        {
                            matrix[secondIndexRow, 0] = 's';

                            //secondIndexRow = secondIndexRow;
                            secondIndexCol = 0;
                        }
                        else
                        {
                            matrix[secondIndexRow, 0] = 'x';
                            break;
                        }
                    }
                }
                else if (moveSecond == "left")
                {
                    if (isInside(matrix, secondIndexRow, secondIndexCol - 1))
                    {
                        if (matrix[secondIndexRow, secondIndexCol - 1] == '*' || matrix[secondIndexRow, secondIndexCol - 1] == 's')
                        {
                            matrix[secondIndexRow, secondIndexCol - 1] = 's';

                            //secondIndexRow = secondIndexRow;
                            secondIndexCol = secondIndexCol -1;
                        }
                        else if (matrix[secondIndexRow, secondIndexCol - 1] == 'f')
                        {
                            matrix[secondIndexRow, secondIndexCol - 1] = 'x';
                            break;
                        }
                    }
                    else
                    {
                        if (matrix[secondIndexRow, num -1] == '*' || matrix[secondIndexRow, num - 1] == 's')
                        {
                            matrix[secondIndexRow, num - 1] = 's';

                            //secondIndexRow = secondIndexRow;
                            secondIndexCol = num -1;
                        }
                        else
                        {
                            matrix[secondIndexRow, num - 1] = 'x';
                            break;
                        }
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        private static bool isInside(char[,] matrix, int row, int col)
        {
            return row < matrix.GetLength(0) && row >= 0
                 && col < matrix.GetLength(1) && col >= 0;
        }
    }
}
