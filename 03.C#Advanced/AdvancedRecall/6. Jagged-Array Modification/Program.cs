using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int[][] jaggetArray = new int[num][];


            for (int i = 0; i < jaggetArray.Length; i++)
            {
                int[] row = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                jaggetArray[i] = row;
            }

            string input = string.Empty;


            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input.Split();

                int x = int.Parse(command[1]);
                int y = int.Parse(command[2]);
                int number = int.Parse(command[3]);


                bool isValidCordinate = IsValidCordinate(x, y, jaggetArray);

                if (command[0] == "Add" && isValidCordinate)
                {
                    jaggetArray[x][y] += number;
                }
                else if (command[0] == "Subtract" && isValidCordinate)
                {
                    jaggetArray[x][y] -= number;
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }

            foreach (var arr in jaggetArray)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }

        public static bool IsValidCordinate(int x, int y, int[][] jaggetArray)
        {
            if (x < 0 || y < 0 || x >= jaggetArray.Length || y >= jaggetArray.Length)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
