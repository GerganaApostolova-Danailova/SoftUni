using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;


namespace _9._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowAndCol = int.Parse(Console.ReadLine());

            char[,] mine = new char[rowAndCol, rowAndCol];

            string[] operations = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int rowS = 0;
            int colS = 0;

            for (int row = 0; row < mine.GetLength(0); row++)
            {
                char[] input = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < mine.GetLength(1); col++)
                {
                    mine[row, col] = input[col];

                    if (mine[row, col] == 's')
                    {
                        rowS = row;
                        colS = col;
                    }
                }
            }

            for (int i = 0; i < operations.Length; i++)
            {
                if (operations[i] == "up")
                {
                    if (!isInside(mine, rowS - 1, colS))
                    {
                        continue;
                    }
                    if (!isNotBreak(mine, rowS - 1, colS))
                    {
                        Console.WriteLine($"Game over! ({rowS - 1}, {colS})");
                        return;
                    }
                    if (isCoal(mine, rowS - 1, colS))
                    {
                        mine[rowS - 1, colS] = '*';

                        if (isNoCoals(mine))
                        {
                            Console.WriteLine($"You collected all coals! ({rowS - 1}, {colS})");
                            return;
                        }
                    }

                    rowS -= 1;
                    colS = colS;
                }
                else if (operations[i] == "down")
                {
                    if (!isInside(mine, rowS + 1, colS))
                    {
                        continue;
                    }
                    if (!isNotBreak(mine, rowS + 1, colS))
                    {
                        Console.WriteLine($"Game over! ({rowS + 1}, {colS})");
                        return;
                    }
                    if (isCoal(mine, rowS + 1, colS))
                    {
                        mine[rowS + 1, colS] = '*';

                        if (isNoCoals(mine))
                        {
                            Console.WriteLine($"You collected all coals! ({rowS + 1}, {colS})");
                            return;
                        }
                    }

                    rowS+= 1;
                    colS = colS;
                }
                else if (operations[i] == "right")
                {
                    if (!isInside(mine, rowS, colS + 1))
                    {
                        continue;
                    }
                    if (!isNotBreak(mine, rowS, colS + 1))
                    {
                        Console.WriteLine($"Game over! ({rowS}, {colS + 1})");
                        return;
                    }
                    if (isCoal(mine, rowS, colS + 1))
                    {
                        mine[rowS, colS + 1] = '*';

                        if (isNoCoals(mine))
                        {
                            Console.WriteLine($"You collected all coals! ({rowS}, {colS + 1})");
                            return;
                        }
                    }

                    rowS = rowS;
                    colS += 1;
                }
                else if (operations[i] == "left")
                {
                    if (!isInside(mine, rowS, colS - 1))
                    {
                        continue;
                    }
                    if (!isNotBreak(mine, rowS, colS - 1))
                    {
                        Console.WriteLine($"Game over! ({rowS}, {colS - 1})");
                        return;
                    }
                    if (isCoal(mine, rowS, colS - 1))
                    {
                        mine[rowS, colS - 1] = '*';

                        if (isNoCoals(mine))
                        {
                            Console.WriteLine($"You collected all coals! ({rowS}, {colS - 1})");
                            return;
                        }
                    }

                    rowS = rowS;
                    colS -= 1;
                }
                if (i == operations.Length - 1)
                {
                    int countCoals = 0;

                    for (int row = 0; row < mine.GetLength(0); row++)
                    {
                        for (int col = 0; col < mine.GetLength(1); col++)
                        {
                            if (mine[row, col] == 'c')
                            {
                                countCoals++;
                            }
                        }
                    }
                    Console.WriteLine($"{countCoals} coals left. ({rowS}, {colS})");
                    return;
                }

            }
        }

        private static bool isNoCoals(char[,] mine)
        {
            bool isValid = false;

            for (int row = 0; row < mine.GetLength(0); row++)
            {
                for (int col = 0; col < mine.GetLength(1); col++)
                {
                    if (mine[row, col] == 'c')
                    {
                        isValid = true;
                    }
                }
            }
            if (isValid)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static bool isCoal(char[,] mine, int rowS, int colS)
        {
            return mine[rowS, colS] == 'c';
        }

        private static bool isNotBreak(char[,] mine, int rowS, int colS)
        {
            return mine[rowS, colS] != 'e';
        }

        private static bool isInside(char[,] mine, int rowS, int colS)
        {
            return rowS < mine.GetLength(0) && rowS >= 0
                 && colS < mine.GetLength(1) && colS >= 0;
        }
    }
}
