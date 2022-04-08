using System;

namespace _09._Sum_of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int minValue = int.MaxValue;

            int sum = 0;
            int count = 0;

            for (int i = 1; i <= 500; i+=2)
            {
                Console.WriteLine(i);
                    sum += i;
                count++;
                if (count == n)
                {
                    break;
                }
                
            }
            Console.WriteLine($"Sum: {sum}");

        }
    }
}
