using System;

namespace _01RhombusofStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                PrintRow(i, num);
            }

            for (int i = num - 1; i > 0; i--)
            {
                PrintRow(i, num);
            }
        }

        private static void PrintRow(int stars, int totalStars)
        {
            int freeSpaces = totalStars - stars;
            Console.Write(new string(' ', freeSpaces));

            for (int i = 0; i < stars - 1; i++)
            {
                Console.Write("* ");
            }
            Console.Write("*");
            Console.WriteLine();
        }
    }
}
