using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Space_Station_Establishment
{
    class Program
    {
        static void Main(string[] args)
        {

            int numOfMatrix = int.Parse(Console.ReadLine());

            char[][] matrix = new char[numOfMatrix][];

            int rowOfStephen = 0;
            int colOfStephen = 0;

            int rowOfHole1 = 0;
            int colOfHole1 = 0;

            int rowOfHole2 = 0;
            int colOfHole2 = 0;

            bool HaveOneHole = false;

            int power = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .ToCharArray();

                matrix[row] = new char[currentRow.Length];


                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = currentRow[col];

                    if (matrix[row][col] == 'S')
                    {
                        rowOfStephen = row;
                        colOfStephen = col;
                    }
                    if (matrix[row][col] == 'O' && !HaveOneHole)
                    {
                        rowOfHole1 = row;
                        colOfHole1 = col;
                        matrix[row][col] = '-';
                        HaveOneHole = true;
                    }
                    if (matrix[row][col] == 'O' && HaveOneHole)
                    {
                        rowOfHole2 = row;
                        colOfHole2 = col;
                        matrix[row][col] = '-';
                    }
                }
            }

            while (power < 50)
            {
                string move = Console.ReadLine();

                if (move == "up")
                {
                    if (isInside(matrix, rowOfStephen - 1, colOfStephen))
                    {
                        if (char.IsDigit(matrix[rowOfStephen - 1][colOfStephen]))
                        {
                            int currentStar = matrix[rowOfStephen - 1][colOfStephen] - 48;
                            power += currentStar;
                            matrix[rowOfStephen - 1][colOfStephen] = 'S';
                            matrix[rowOfStephen][colOfStephen] = '-';
                            rowOfStephen--;
                        }
                        else if (rowOfStephen - 1 == rowOfHole1 && rowOfStephen == colOfHole1)
                        {
                            matrix[rowOfStephen][colOfStephen] = '-';
                            matrix[rowOfHole2][colOfHole2] = 'S';
                            rowOfStephen = rowOfHole2;
                            colOfStephen = colOfHole2;
                        }
                        else if (rowOfStephen - 1 == rowOfHole2 && rowOfStephen == colOfHole2)
                        {
                            matrix[rowOfStephen][colOfStephen] = '-';
                            matrix[rowOfHole1][colOfHole1] = 'S';
                            rowOfStephen = rowOfHole1;
                            colOfStephen = colOfHole1;
                        }
                        else if (matrix[rowOfStephen - 1][colOfStephen] == '-')
                        {
                            matrix[rowOfStephen - 1][colOfStephen] = 'S';
                            matrix[rowOfStephen][colOfStephen] = '-';
                            rowOfStephen--;
                        }
                    }
                    else
                    {
                        matrix[rowOfStephen][colOfStephen] = '-';
                        Console.WriteLine("Bad news, the spaceship went to the void.");
                        break;
                    }
                }
                else if (move == "down")
                {
                    if (isInside(matrix, rowOfStephen + 1, colOfStephen))
                    {
                        if (char.IsDigit(matrix[rowOfStephen + 1][colOfStephen]))
                        {
                            int currentStar = matrix[rowOfStephen + 1][colOfStephen] - 48;
                            power += currentStar;
                            matrix[rowOfStephen + 1][colOfStephen] = 'S';
                            matrix[rowOfStephen][colOfStephen] = '-';
                            rowOfStephen++;
                        }
                        else if (matrix[rowOfStephen + 1][colOfStephen] == 'O')
                        {
                            if (rowOfStephen + 1 == rowOfHole1 && rowOfStephen == colOfHole1)
                            {
                                matrix[rowOfStephen][colOfStephen] = '-';
                                matrix[rowOfHole2][colOfHole2] = 'S';
                                rowOfStephen = rowOfHole2;
                                colOfStephen = colOfHole2;
                            }
                            else if (rowOfStephen + 1 == rowOfHole2 && rowOfStephen == colOfHole2)
                            {
                                matrix[rowOfStephen][colOfStephen] = '-';
                                matrix[rowOfHole1][colOfHole1] = 'S';
                                rowOfStephen = rowOfHole1;
                                colOfStephen = colOfHole1;
                            }
                        }
                        else if (matrix[rowOfStephen + 1][colOfStephen] == '-')
                        {
                            matrix[rowOfStephen + 1][colOfStephen] = 'S';
                            matrix[rowOfStephen][colOfStephen] = '-';
                            rowOfStephen++;
                        }
                    }
                    else
                    {
                        matrix[rowOfStephen][colOfStephen] = '-';
                        Console.WriteLine("Bad news, the spaceship went to the void.");
                        break;
                    }
                }
                else if (move == "right")
                {
                    if (isInside(matrix, rowOfStephen, colOfStephen + 1))
                    {
                        if (char.IsDigit(matrix[rowOfStephen][colOfStephen + 1]))
                        {
                            int currentStar = matrix[rowOfStephen][colOfStephen + 1] - 48;
                            power += currentStar;
                            matrix[rowOfStephen][colOfStephen + 1] = 'S';
                            matrix[rowOfStephen][colOfStephen] = '-';
                            colOfStephen++;
                        }
                        else if (rowOfStephen == rowOfHole1 && rowOfStephen + 1 == colOfHole1)
                        {
                            matrix[rowOfStephen][colOfStephen] = '-';
                            matrix[rowOfHole2][colOfHole2] = 'S';
                            rowOfStephen = rowOfHole2;
                            colOfStephen = colOfHole2;
                        }
                        else if (rowOfStephen == rowOfHole2 && rowOfStephen + 1 == colOfHole2)
                        {
                            matrix[rowOfStephen][colOfStephen] = '-';
                            matrix[rowOfHole1][colOfHole1] = 'S';
                            rowOfStephen = rowOfHole1;
                            colOfStephen = colOfHole1;
                        }
                        else if (matrix[rowOfStephen][colOfStephen + 1] == '-')
                        {
                            matrix[rowOfStephen][colOfStephen + 1] = 'S';
                            matrix[rowOfStephen][colOfStephen] = '-';
                            colOfStephen++;
                        }
                    }
                    else
                    {
                        matrix[rowOfStephen][colOfStephen] = '-';
                        Console.WriteLine("Bad news, the spaceship went to the void.");
                        break;
                    }
                }
                else if (move == "left")
                {
                    if (isInside(matrix, rowOfStephen, colOfStephen - 1))
                    {
                        if (char.IsDigit(matrix[rowOfStephen][colOfStephen - 1]))
                        {
                            int currentStar = matrix[rowOfStephen][colOfStephen - 1] - 48;
                            power += currentStar;
                            matrix[rowOfStephen][colOfStephen - 1] = 'S';
                            matrix[rowOfStephen][colOfStephen] = '-';
                            colOfStephen--;
                        }
                        else if (rowOfStephen == rowOfHole1 && rowOfStephen - 1 == colOfHole1)
                        {
                            matrix[rowOfStephen][colOfStephen] = '-';
                            matrix[rowOfHole2][colOfHole2] = 'S';
                            rowOfStephen = rowOfHole2;
                            colOfStephen = colOfHole2;
                        }
                        else if (rowOfStephen == rowOfHole2 && rowOfStephen - 1 == colOfHole2)
                        {
                            matrix[rowOfStephen][colOfStephen - 1] = '-';
                            matrix[rowOfHole1][colOfHole1] = '-';
                            rowOfStephen = rowOfHole1;
                            colOfStephen = colOfHole1;
                        }
                        else if (matrix[rowOfStephen][colOfStephen - 1] == '-')
                        {
                            matrix[rowOfStephen][colOfStephen - 1] = 'S';
                            matrix[rowOfStephen][colOfStephen] = '-';
                            colOfStephen--;
                        }
                    }
                    else
                    {
                        matrix[rowOfStephen][colOfStephen] = '-';
                        Console.WriteLine("Bad news, the spaceship went to the void.");
                        break;
                    }
                }
            }

            if (power >= 50)
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            }

            Console.WriteLine($"Star power collected: {power}");
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
