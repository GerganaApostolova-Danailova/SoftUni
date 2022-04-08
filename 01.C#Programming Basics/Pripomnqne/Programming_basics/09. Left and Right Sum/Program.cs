using System;

namespace _09._Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int rightSum = 0;
            int leftSum = 0;


            for (int i = 0; i < num; i++)
            {
                int input = int.Parse(Console.ReadLine());

                rightSum += input;
            }

            for (int i = 0; i < num; i++)
            {
                int input = int.Parse(Console.ReadLine());

                leftSum += input;
            }

            if (rightSum == leftSum)
            {
                Console.WriteLine($"Yes, sum = {rightSum}");
            }
            else
            {
                int diff = Math.Abs(rightSum - leftSum);

                Console.WriteLine($"No, diff = {diff}");
            }
        }
    }
}
