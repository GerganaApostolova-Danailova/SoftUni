using System;

namespace _08._Number_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int maxNum = int.MinValue;
            int minNum = int.MaxValue;

            for (int i = 0; i < num; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (input > maxNum)
                {
                    maxNum = input;
                }
                if (input < minNum)
                {
                    minNum = input;
                }
            }

            Console.WriteLine($"Max number: {maxNum}");
            Console.WriteLine($"Min number: {minNum}");

        }
    }
}
