using System;
using System.Linq;

namespace _06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            if (numbers.Length == 1)
            {
                Console.WriteLine(0);
                return;
            }
            int sum1 = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i > 0)
                {
                    sum1 += numbers[i - 1];
                }

                int sum2 = 0;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    sum2 += numbers[j];
                }
                if (sum1 == sum2)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine("no");
        }
    }
}
