using System;

namespace Area_of_Trapezoid
{
    class Program
    {
        static void Main(string[] args)
        {
            double b1 = double.Parse(Console.ReadLine());
            double b2 = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double area = (b1 + b2) / 2 * h;

            Console.WriteLine($"{area:F2}");

        }
    }
}
