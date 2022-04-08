using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num1; i++)
            {
                for (int j = 1; j <= num2; j++)
                {
                    for (int k = 1; k <= num3; k++)
                    {
                        bool more = (j == 2 || j == 3 || j == 5 || j == 7) ;

                        if (i % 2==0 && k % 2 ==0 && more)
                        {
                            Console.WriteLine($"{i} {j} {k}");
                        }
                    }
                }
            }

        }
    }
}
