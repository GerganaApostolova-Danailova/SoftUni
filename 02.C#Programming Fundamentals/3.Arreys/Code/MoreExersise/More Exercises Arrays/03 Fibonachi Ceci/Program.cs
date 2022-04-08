using System;

namespace _03_Fibonachi_Ceci
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            double f1 = 0;
            double f2 = 1;

            while ((num--) > 0)
            {
                f2 = f1 + f2;
                f1 = f2 - f1;
            }
            Console.WriteLine(f1);
        }
    }
}
