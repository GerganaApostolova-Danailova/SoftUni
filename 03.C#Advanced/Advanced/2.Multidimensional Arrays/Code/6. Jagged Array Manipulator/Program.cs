using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jaggetArrey = new double[rows][];

            for (int row = 0; row < jaggetArrey.Length; row++)
            {
                double[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                jaggetArrey[row] = currentRow;
            }
            for (int row = 0; row < jaggetArrey.Length - 1; row++)
            {
                if (jaggetArrey[row].Length == jaggetArrey[row + 1].Length)
                {
                    jaggetArrey[row] = jaggetArrey[row].Select(x => x * 2).ToArray();
                    jaggetArrey[row + 1] = jaggetArrey[row + 1].Select(x => x * 2).ToArray();
                    break;
                }
                else
                {
                    jaggetArrey[row] = jaggetArrey[row].Select(x => x / 2).ToArray();
                    jaggetArrey[row + 1] = jaggetArrey[row + 1].Select(x => x / 2).ToArray();
                    break;
                }
            }


            while (true)
            {

                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string operation = command[0];

                if (operation == "End")
                {
                    break;
                }

                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (operation == "Add" && isValid(jaggetArrey, row, col))
                {
                    jaggetArrey[row][col] += value;
                }
                else if (operation == "Subtract" && isValid(jaggetArrey, row, col))
                {
                    jaggetArrey[row][col] -= value;
                }

            }

            foreach (double[] row in jaggetArrey)
            {
                Console.WriteLine(string.Join(" ", row));
            }

        }

        private static bool isValid(double[][] jaggetArrey, int row, int col)
        {
            return row >= 0 && jaggetArrey.Length > row
                && col >= 0 && jaggetArrey[row].Length > col;
        }
    }
}
