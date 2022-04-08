using System;

namespace _07._NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                PrintNum(num);
                Console.WriteLine();
            }
        }

        static void PrintNum(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Console.Write(num + " ");
            }
        }
    }
}
