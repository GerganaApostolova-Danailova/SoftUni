using System;

namespace _08._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double pow = double.Parse(Console.ReadLine());

            double result = GetPow(num,pow);
            Console.WriteLine(result);
        }
        static double GetPow(double num, double pow)
        {
            double result = Math.Pow(num, pow);

            return result;
        }
    }
}
