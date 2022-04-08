using System;

namespace _01._Convert_Meters_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {

            double metric = int.Parse(Console.ReadLine());

            double kilometric = metric / 1000;
            Console.WriteLine($"{kilometric:f2}");
        }
    }
}
