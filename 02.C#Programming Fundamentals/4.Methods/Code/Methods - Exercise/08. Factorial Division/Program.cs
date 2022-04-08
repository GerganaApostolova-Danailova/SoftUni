using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            PrintDevide(num1, num2);

        }

        private static void PrintDevide(int num1, int num2)
        {

            int result3 = PrintNum2Facturiel(num2, num1);

            Console.WriteLine($"{result3:f2}");

        }

        static int PrintNum2Facturiel(int num2, int num1)
        {
            int result2 = 1;
            for (int i = 1; i <= num2; i++)
            {
                result2 *= i;
            }

            

            int result1 = 1;
            for (int i = 1; i <= num1; i++)
            {
                result1 *= i;
            }

            int final = 0;

            final = result1 / result2;
            return final;
        }

        
    }
}
