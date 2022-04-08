using System;

namespace _10._Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int rightSum = 0;
            int leftSum = 0;


            for (int i = 1; i <= num; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    rightSum += input;
                }
                else
                {
                    leftSum += input;
                }
            }

            if (rightSum == leftSum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {rightSum}");
            }
            else
            {
                int diff = Math.Abs(rightSum - leftSum);

                Console.WriteLine("No");
                Console.WriteLine($"Diff = {diff}");
            }
        }
    }
}
