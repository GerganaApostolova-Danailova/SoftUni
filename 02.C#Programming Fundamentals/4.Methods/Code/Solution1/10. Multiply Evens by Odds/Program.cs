using System;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = Math.Abs(int.Parse(Console.ReadLine()));


            int result = GetMultiplleEvevAndOdd(num);
            Console.WriteLine(result);


        }

    static int GetMultiplleEvevAndOdd(int num)
    {
        int sumOdd = GetSumOfOddDigits(num);
        int sumEven = GetSumOfEvenDigits(num);
        return sumOdd * sumEven;
    }
    static int GetSumOfOddDigits(int num)
    {
        int sumOdd = 0;

        while (num > 0)
        {
            int lastDigit = num % 10;
            num = num / 10;

            if (lastDigit % 2 != 0)
            {

                sumOdd += lastDigit;

            }


        }
        return sumOdd;
    }

    static int GetSumOfEvenDigits(int num)
    {

        int sumEven = 0;
        while (num > 0)
        {

            int lastDigit = num % 10;
            num = num / 10;

            if (lastDigit % 2 == 0)
            {

                sumEven += lastDigit;

            }

        }
        return sumEven;
    }
    }

}


