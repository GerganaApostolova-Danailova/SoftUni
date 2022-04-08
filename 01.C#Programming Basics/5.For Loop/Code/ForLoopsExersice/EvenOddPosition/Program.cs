using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double oddSum = 0.0;
            double evenSum = 0.0;
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;

            for (double i = 1; i <= n; i++)
            {
                double num = double.Parse(Console.ReadLine());

                if (i % 2 == 0)  //even
                {
                    evenSum += num;
                    if (num < evenMin)
                    {
                        evenMin = num;
                    }
                    if (num > evenMax)
                    {
                        evenMax = num;
                    }
                }
                else    //odd
                {
                    oddSum += num;
                    if (num < oddMin)
                    {
                        oddMin = num;
                    }
                    if (num > oddMax)
                    {
                        oddMax = num;
                    }
                }
            }
            Console.WriteLine($"OddSum={oddSum:f2},");
            if ( n < 1)
                {
                Console.WriteLine("OddMin=No,");
                Console.WriteLine("OddMax=No,");

            }
            else
            {
                Console.WriteLine($"OddMin={oddMin:f2},");
                Console.WriteLine($"OddMax={oddMax:f2},");
            }
            Console.WriteLine($"EvenSum={evenSum:f2},");
            if (n < 2)
            {
                Console.WriteLine("EvenMin=No,");
                Console.WriteLine("EvenMax=No");

            }
            else
            {
                Console.WriteLine($"EvenMin={evenMin:f2},");
                Console.WriteLine($"EvenMax={evenMax:f2}");
            }
        }
    }
}
