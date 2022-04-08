using System;
using System.Numerics;

namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numBalls = int.Parse(Console.ReadLine());

            BigInteger maxValue = 0; ;
            string result = string.Empty;


            for (int i = 0; i < numBalls; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);
                if (snowballValue >= maxValue)
                {
                    maxValue = snowballValue;
                    result = ($"{snowballSnow} : {snowballTime} = {snowballValue} ({snowballQuality})");
                }
            }

            Console.WriteLine(result);

        }
    }
}
