using System;

namespace _06._Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {   
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            Console.WriteLine(GetRectangleArea(a, b)); 

        }

        static double GetRectangleArea(double a, double b)
        {
            return a * b;
        }
    }
}
