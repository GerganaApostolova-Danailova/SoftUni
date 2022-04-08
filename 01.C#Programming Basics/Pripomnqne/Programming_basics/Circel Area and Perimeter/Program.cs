using System;

namespace Circel_Area_and_Perimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            double radios = double.Parse(Console.ReadLine());

            double area = Math.PI * radios * radios;

            double perimeter = 2 * Math.PI * radios;

            Console.WriteLine($"{area:F2}");
            Console.WriteLine($"{perimeter:F2}");

        }
    }
}
