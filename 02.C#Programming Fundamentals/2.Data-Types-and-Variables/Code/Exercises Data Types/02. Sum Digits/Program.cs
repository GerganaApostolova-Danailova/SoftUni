using System;

namespace _02._Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {


            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = n; i > 0; i = i / 10)
            {
                sum = sum + i % 10;
            }
            Console.WriteLine(sum);
            Console.ReadLine();


        }
    }
}
