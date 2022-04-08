using System;

namespace _10._Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int fromWhere = int.Parse(Console.ReadLine());

            int result = 0;


            if (fromWhere <= 10)
            {
                for (int i = fromWhere; i <= 10; i++)
                {
                    result = i * n;
                    Console.WriteLine($"{n} X {i} = {result}");
                }
            }

            else
            {
                result = n * fromWhere;
                Console.WriteLine($"{n} X {fromWhere} = {result}");
            }
            
        }
    }
}
