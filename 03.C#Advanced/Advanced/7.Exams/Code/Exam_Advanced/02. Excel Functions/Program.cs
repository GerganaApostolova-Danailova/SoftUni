using System;
using System.Linq;

namespace _02._Excel_Functions
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberRow = int.Parse(Console.ReadLine());

            string[][] table = new string[numberRow][];

            for (int i = 0; i < numberRow; i++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split(", ");

                table[i] = currentRow;
            }

            string[] commandArt = Console.ReadLine()
                .Split();

            string command = commandArt[0];
            string header = commandArt[1];

            int headerIndex = Array.IndexOf(table[0], header);


            if (command == "hide")
            {

                for (int row = 0; row < table.Length; row++)
                {
                    Console.WriteLine(string.Join(" | ", table[row]
                        .Where((x, i) => i != headerIndex)
                        .ToArray()));
                }
            }
            else if (command == "sort")
            {
                string[] headerRow = table[0];

                Console.WriteLine(string.Join(" | ", headerRow));

                table = table
                    .OrderBy(x => x[headerIndex])
                    .ToArray();

                foreach (var row in table)
                {
                    if (row != headerRow)
                    {
                        Console.WriteLine(string.Join(" | ", row));
                    }
                }
            }
            else if (command == "filter")
            {
                string value = commandArt[2];

                string[] headerRow = table[0];

                Console.WriteLine(string.Join(" | ", headerRow));

                table = table
                    .Where(x => x[headerIndex] == value)
                    .ToArray();

                foreach (var row in table)
                {
                Console.WriteLine(string.Join(" | ",row));

                }
            }
        }
    }
}
