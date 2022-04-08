using System;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = Math.Abs(int.Parse(Console.ReadLine()));

            string num = input.ToString();

            int evenSum = GetSumOfEvenDigits(num);

            int oddSum = GetSumOfOddDigits(num);

            int output = GetMultipleOfEvenAndOdds(evenSum, oddSum);

            Console.WriteLine(output);
        }

         static int GetMultipleOfEvenAndOdds(int evenSum, int oddSum)
        {
            return evenSum * oddSum;
        }

        static int GetSumOfOddDigits(string num) //нечетно
        {
            int sum = 0;

            for (int i = 0; i < num.Length; i++)
            {
                int value = (int)Char.GetNumericValue(num[i]);
                value = Math.Abs(value);

                if (value % 2 != 0)
                {
                    sum += value;
                }
            }
            return sum;
        }
        static int GetSumOfEvenDigits(string num) // четно
        {
            int sum = 0;

            for (int i = 0; i < num.Length; i++)
            {
                int value = (int)Char.GetNumericValue(num[i]);
                value = Math.Abs(value);

                if (value % 2 == 0)
                {
                    sum += value;
                }
            }
            return sum;
        }
    }
}
