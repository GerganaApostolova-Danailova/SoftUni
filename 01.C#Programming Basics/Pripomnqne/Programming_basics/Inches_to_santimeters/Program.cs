using System;

namespace Inches_to_santimeters
{
    class Program
    {
        static void Main(string[] args)
        {
            double inches = double.Parse(Console.ReadLine());

            double santimeters = inches * 2.54;

            Console.WriteLine($"{santimeters:f2}");
            
        }
    }
}
