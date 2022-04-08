using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03_JediGalaxy
{
    public class Engine
    {
        private int[,] matrix;
        private long totalSum;

        public void Run()
        {
            int[] imensions = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = imensions[0];
            int cols = imensions[1];

            this.InicializeMatrix(rows, cols);

            string command = Console.ReadLine();

            while (command != "Let the Force be with you")
            {
                int[] playerCordinates = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] evilCordinates = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int evelRow = evilCordinates[0];
                int evelCol = evilCordinates[1];

                MoveEvelToTopLeftCorner(evelRow, evelCol);

                int playerRow = playerCordinates[0];
                int playerCol = playerCordinates[1];

                MovePlayerToTopRightCorner(playerRow, playerCol);

                command = Console.ReadLine();
            }

            Console.WriteLine(totalSum);
        }

        private void MovePlayerToTopRightCorner(int playerRow,int playerCol)
        {
            while (playerRow >= 0 && playerCol < matrix.GetLength(1))
            {
                if (IsInside(playerRow, playerCol))
                {
                    totalSum += matrix[playerRow, playerCol];
                }

                playerCol++;
                playerRow--;
            }
        }

        private void MoveEvelToTopLeftCorner(int evelRow,int evelCol)
        {
            while (evelRow >= 0 && evelCol >= 0)
            {
                if (this.IsInside(evelRow, evelCol))
                {
                    matrix[evelRow, evelCol] = 0;
                }
                evelRow--;
                evelCol--;
            }
        }

        private bool IsInside(int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < matrix.GetLength(0) 
                && targetCol >= 0 && targetCol < matrix.GetLength(1);
        }

        private void InicializeMatrix(int rows, int cols)
        {
            matrix = new int[rows, cols];

            int value = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = value++;
                }
            }
        }
    }
}

