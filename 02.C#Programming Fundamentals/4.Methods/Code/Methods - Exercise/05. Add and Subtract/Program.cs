using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            PrintResult(num1, num2, num3);

        }

         static void PrintResult(int num1, int num2, int num3)
        {
            int finalResult = (GetSum(num1, num2)) - num3;

            Console.WriteLine(finalResult);
          
        }

        static int GetSum(int num1, int num2)
        {
            int result = 0;

            result = num1 + num2;
            return result;
        }
    }
}
