using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowAndCol = int.Parse(Console.ReadLine());

            char[,] chest = new char[rowAndCol, rowAndCol];

            for (int row = 0; row < chest.GetLength(0); row++)
            {
                char[] input = Console.ReadLine()
                    .ToCharArray();
                for (int col = 0; col < chest.GetLength(1); col++)
                {
                    chest[row, col] = input[col];
                }
            }

            int elimnateKnight = 0;

            while (true)
            {
                int maxAttack = 0;
                int currentRow = 0;
                int currentCol = 0;

                for (int row = 0; row < chest.GetLength(0); row++)
                {
                    for (int col = 0; col < chest.GetLength(1); col++)
                    {
                        int counAttack = 0;

                        if (chest[row, col] == 'K')
                        {
                            if (isInside(chest, row - 2, col + 1) && chest[row - 2, col + 1] == 'K')
                            {
                                counAttack++;

                            }
                            if (isInside(chest, row - 2, col - 1) && chest[row - 2, col - 1] == 'K')
                            {
                                counAttack++;
                            }
                            if (isInside(chest, row - 1, col + 2) && chest[row - 1, col + 2] == 'K')
                            {
                                counAttack++;
                            }
                            if (isInside(chest, row + 1, col + 2) && chest[row + 1, col + 2] == 'K')
                            {
                                counAttack++;
                            }
                            if (isInside(chest, row - 1, col - 2) && chest[row - 1, col - 2] == 'K')
                            {
                                counAttack++;
                            }
                            if (isInside(chest, row + 1, col - 2) && chest[row + 1, col - 2] == 'K')
                            {
                                counAttack++;
                            }
                            if (isInside(chest, row + 2, col - 1) && chest[row + 2, col - 1] == 'K')
                            {
                                counAttack++;
                            }
                            if (isInside(chest, row + 2, col + 1) && chest[row + 2, col + 1] == 'K')
                            {
                                counAttack++;
                            }
                        }
                        if (counAttack > maxAttack)
                        {
                            maxAttack = counAttack;
                            currentRow = row;
                            currentCol = col;
                        }
                    }
                }
                if (maxAttack == 0)
                {
                    break;
                }

                elimnateKnight++;
                chest[currentRow, currentCol] = '0';
            }

            Console.WriteLine(elimnateKnight);
        }

        private static bool isInside(char[,] chest, int row, int col)
        {
            return row < chest.GetLength(0) && row >= 0
                 && col < chest.GetLength(1) && col >= 0;
        }
    }
}
