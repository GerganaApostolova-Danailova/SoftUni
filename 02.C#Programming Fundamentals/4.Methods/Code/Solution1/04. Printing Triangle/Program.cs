using System;

namespace _04._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            PrintTriange(num);
          
        }

        private static void PrintTriange(int num)
        {
            PrintUpperPart(num);
            PrintLowerPart(num);
        }

        private static void PrintUpperPart(int num)
        {
            for (int row = 1; row <= num; row++)
            {
                for (int col = 1; col <= row; col++)
                {
                    Console.Write(col + " ");
                }
                Console.WriteLine();
            }
        }

        private static void PrintLowerPart(int num)
        {
            for (int row = num - 1; row >= 1; row--)
            {
                for (int col = 1; col <= row; col++)
                {
                    Console.Write(col+ " ");
                }
                Console.WriteLine();
            }
        }
    }
}
