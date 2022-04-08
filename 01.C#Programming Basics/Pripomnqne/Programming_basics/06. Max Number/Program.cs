using System;

namespace _06._Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int count = 0;

            int max = int.MinValue; ;

            while (count < n)
            {
                int number = int.Parse(Console.ReadLine());

                if (number > max)
                {
                    max = number;
                }

                count++;
            }

            Console.WriteLine(max);
        }
    }
}
