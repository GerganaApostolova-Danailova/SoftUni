using System;

namespace _07._Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int count = 0;

            int min = int.MaxValue; ;

            while (count < n)
            {
                int number = int.Parse(Console.ReadLine());

                if (number < min)
                {
                    min = number;
                }

                count++;
            }

            Console.WriteLine(min);
        }
    }
}
