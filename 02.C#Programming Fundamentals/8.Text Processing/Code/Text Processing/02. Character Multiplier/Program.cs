using System;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split();

            string fistInInput = input[0];
            string secondInInput = input[1];


            int maxLenght = 0;
            int minLenght = 0;

            int sum = 0;

            if (fistInInput.Length > secondInInput.Length)
            {
                maxLenght = fistInInput.Length;
                minLenght = secondInInput.Length;

                for (int i = minLenght; i < maxLenght; i++)
                {
                    sum += fistInInput[i];
                }
            }
            else
            {
                minLenght = fistInInput.Length;
                maxLenght = secondInInput.Length;

                for (int i = minLenght; i < maxLenght; i++)
                {
                    sum += secondInInput[i];
                }
            }

            for (int i = 0; i < minLenght; i++)
            {
                sum += fistInInput[i] * secondInInput[i];
            }

            Console.WriteLine($"{sum}");
        }
    }
}
