using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int count200 = 0;
            int count399 = 0;
            int count599 = 0;
            int count799 = 0;
            int count800 = 0;
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;

            for ( int i=0; i <n; i++)
            {
                double num = double.Parse(Console.ReadLine());

                if (num < 200)
                {
                    count200 += 1;
                }
                else if(num >=200 && num <= 399)
                {
                    count399 += 1;
                }
                else if (num >= 400 && num <= 599)
                {
                    count599 += 1;
                }
                else if (num >= 600 && num <= 799)
                {
                    count799 += 1;
                }
                else if (num >= 800)
                {
                    count800 += 1;
                }
            }

            p1 = ((double)count200 / n) * 100;
            p2 = ((double)count399 / n) * 100;
            p3 = ((double)count599 / n) * 100;
            p4 = ((double)count799 / n) * 100;
            p5 = ((double)count800 / n) * 100;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
            Console.WriteLine($"{p4:f2}%");
            Console.WriteLine($"{p5:f2}%");

        }
    }
}
