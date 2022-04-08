using System;

namespace _03._Floating_Equality
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            double result = Math.Abs(a - b);

            if (result > 0.000001)
            {
                Console.WriteLine("False");
            }
            else
            {
                Console.WriteLine("True");
            }
        }
    }
}
