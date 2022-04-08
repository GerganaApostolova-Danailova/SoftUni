using System;

namespace Exercises_Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            int num4 = int.Parse(Console.ReadLine());

            int sum = num1 + num2;
            int devide = sum / num3;
            int result = devide * num4;

            Console.WriteLine(result);


        }
    }
}
