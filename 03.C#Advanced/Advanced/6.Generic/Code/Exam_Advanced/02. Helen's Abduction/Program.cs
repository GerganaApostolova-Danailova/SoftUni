using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Helen_s_Abduction
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());

            int numOfMatrix = int.Parse(Console.ReadLine());

            char[][] matrix = new char[numOfMatrix][];

            int rowOfParis = 0;
            int colOfParis = 0;

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
                        rowOfParis = row;
                        colOfParis = col;
                        matrix[row][col] = '-';
                    }
                }
            }
            
            while (true)
            {
                string[] currentMove = Console.ReadLine()
                    .Split();

                string move = currentMove[0];
                int rowOfSpartan = int.Parse(currentMove[1]);
                int colOfSpartan = int.Parse(currentMove[2]);


                matrix[rowOfSpartan][colOfSpartan] = 'S';

                if (move == "up")
                {
                    if (isInside(matrix, rowOfParis - 1, colOfParis))
                    {
                        if (matrix[rowOfParis - 1][colOfParis] == '-')
                        {
                            if (energy - 1 > 0)
                            {
                                energy -= 1;
                            }
                            else
                            {
                                matrix[rowOfParis - 1][colOfParis] = 'X';
                                matrix[rowOfParis][colOfParis] = '-';
                                Console.WriteLine($"Paris died at {rowOfParis - 1};{colOfParis}.");
                                break;
                            }
                            matrix[rowOfParis][colOfParis] = '-';

                            rowOfParis--;
                        }
                        else if (matrix[rowOfParis - 1][colOfParis] == 'S')
                        {
                            if (energy - 3 > 0)
                            {
                                energy -= 3;
                            }
                            else
                            {
                                matrix[rowOfParis - 1][colOfParis] = 'X';
                                matrix[rowOfParis][colOfParis] = '-';
                                Console.WriteLine($"Paris died at {rowOfParis - 1};{colOfParis}.");
                                break;
                            }
                            matrix[rowOfParis][colOfParis] = '-';

                            rowOfParis--;

                        }
                        else if (matrix[rowOfParis - 1][colOfParis] == 'H')
                        {
                            if (energy >= 1)
                            {
                                energy -= 1;
                            }
                            else
                            {
                                energy = 0;
                            }
                            Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
                            matrix[rowOfParis][colOfParis] = '-';
                            matrix[rowOfParis - 1][colOfParis] = '-';
                            break;
                        }
                    }
                    else
                    {
                        if (energy - 1 > 0)
                        {
                            energy -= 1;
                        }
                        else
                        {
                            matrix[rowOfParis][colOfParis] = 'X';
                            Console.WriteLine($"Paris died at {rowOfParis};{colOfParis}.");
                            break;
                        }
                    }
                }
                else if (move == "down")
                {
                    if (isInside(matrix, rowOfParis + 1, colOfParis))
                    {
                        if (matrix[rowOfParis + 1][colOfParis] == '-')
                        {
                            if (energy - 1 > 0)
                            {
                                energy -= 1;
                            }
                            else
                            {
                                matrix[rowOfParis + 1][colOfParis] = 'X';
                                matrix[rowOfParis][colOfParis] = '-';
                                Console.WriteLine($"Paris died at {rowOfParis + 1};{colOfParis}.");
                                break;
                            }
                            matrix[rowOfParis][colOfParis] = '-';
                            rowOfParis++;
                        }
                        else if (matrix[rowOfParis + 1][colOfParis] == 'S')
                        {
                            if (energy - 3 > 0)
                            {
                                energy -= 3;
                            }
                            else
                            {
                                matrix[rowOfParis + 1][colOfParis] = 'X';
                                matrix[rowOfParis][colOfParis] = '-';
                                Console.WriteLine($"Paris died at {rowOfParis + 1};{colOfParis}.");
                                break;
                            }
                            matrix[rowOfParis][colOfParis] = '-';
                            rowOfParis++;
                        }
                        else if (matrix[rowOfParis + 1][colOfParis] == 'H')
                        {
                            if (energy >= 1)
                            {
                                energy -= 1;
                            }
                            else
                            {
                                energy = 0;
                            }
                            Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
                            matrix[rowOfParis][colOfParis] = '-';
                            matrix[rowOfParis + 1][colOfParis] = '-';
                            break;
                        }
                    }
                    else
                    {
                        if (energy - 1 > 0)
                        {
                            energy -= 1;
                        }
                        else
                        {
                            matrix[rowOfParis][colOfParis] = 'X';
                            Console.WriteLine($"Paris died at {rowOfParis};{colOfParis}.");
                            break;
                        }
                    }
                }
                else if (move == "right")
                {
                    if (isInside(matrix, rowOfParis, colOfParis + 1))
                    {
                        if (matrix[rowOfParis][colOfParis + 1] == '-')
                        {
                            if (energy - 1 > 0)
                            {
                                energy -= 1;
                            }
                            else
                            {
                                matrix[rowOfParis][colOfParis + 1] = 'X';
                                matrix[rowOfParis][colOfParis] = '-';
                                Console.WriteLine($"Paris died at {rowOfParis};{colOfParis + 1}.");
                                break;
                            }
                            matrix[rowOfParis][colOfParis] = '-';
                            colOfParis++;
                        }
                        else if (matrix[rowOfParis][colOfParis + 1] == 'S')
                        {
                            if (energy - 3 > 0)
                            {
                                energy -= 3;
                            }
                            else
                            {
                                matrix[rowOfParis][colOfParis + 1] = 'X';
                                matrix[rowOfParis][colOfParis] = '-';
                                Console.WriteLine($"Paris died at {rowOfParis};{colOfParis + 1}.");
                                break;
                            }
                            matrix[rowOfParis][colOfParis] = '-';
                            colOfParis++;
                        }
                        else if (matrix[rowOfParis][colOfParis + 1] == 'H')
                        {
                            if (energy >= 1)
                            {
                                energy -= 1;
                            }
                            else
                            {
                                energy = 0;
                            }
                            Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
                            matrix[rowOfParis][colOfParis] = '-';
                            matrix[rowOfParis][colOfParis + 1] = '-';
                            break;
                        }
                    }
                    else
                    {
                        if (energy - 1 > 0)
                        {
                            energy -= 1;
                        }
                        else
                        {
                            matrix[rowOfParis][colOfParis] = 'X';
                            Console.WriteLine($"Paris died at {rowOfParis};{colOfParis}.");
                            break;
                        }
                    }
                }
                else if (move == "left")
                {
                    if (isInside(matrix, rowOfParis, colOfParis - 1))
                    {
                        if (matrix[rowOfParis][colOfParis - 1] == '-')
                        {
                            if (energy - 1 > 0)
                            {
                                energy -= 1;
                            }
                            else
                            {
                                matrix[rowOfParis][colOfParis - 1] = 'X';
                                matrix[rowOfParis][colOfParis] = '-';
                                Console.WriteLine($"Paris died at {rowOfParis};{colOfParis - 1}.");
                                break;
                            }
                            matrix[rowOfParis][colOfParis] = '-';
                            colOfParis--;
                        }
                        else if (matrix[rowOfParis][colOfParis - 1] == 'S')
                        {
                            if (energy - 3 > 0)
                            {
                                energy -= 3;
                            }
                            else
                            {
                                matrix[rowOfParis][colOfParis - 1] = 'X';
                                matrix[rowOfParis][colOfParis] = '-';
                                Console.WriteLine($"Paris died at {rowOfParis};{colOfParis - 1}.");
                                break;
                            }
                            matrix[rowOfParis][colOfParis] = '-';
                            colOfParis--;
                        }
                        else if (matrix[rowOfParis][colOfParis - 1] == 'H')
                        {
                            if (energy >= 1)
                            {
                                energy -= 1;
                            }
                            else
                            {
                                energy = 0;
                            }

                            Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");

                            matrix[rowOfParis][colOfParis] = '-';
                            matrix[rowOfParis][colOfParis - 1] = '-';
                            break;
                        }
                    }
                    else
                    {
                        if (energy - 1 > 0)
                        {
                            energy -= 1;
                        }
                        else
                        {
                            matrix[rowOfParis][colOfParis] = 'X';
                            Console.WriteLine($"Paris died at {rowOfParis};{colOfParis}.");
                            break;
                        }
                    }
                }
            }
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

