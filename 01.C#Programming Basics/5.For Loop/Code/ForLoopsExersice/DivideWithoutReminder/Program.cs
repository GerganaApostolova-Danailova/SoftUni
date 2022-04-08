using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideWithoutReminder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int count2 = 0;
            int count3 = 0;
            int count4 = 0;
            
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            

            for (int i = 0; i < n; i++)
            {
                double num = double.Parse(Console.ReadLine());

                if (num % 2 ==0)
                {
                    count2 += 1;
                }
                if (num % 3==0)
                {
                    count3 += 1;
                }
                eif (num % 4==0)
                {
                    count4 += 1;
                }
                
            }

            p1 = ((double)count2 / n) * 100;
            p2 = ((double)count3 / n) * 100;
            p3 = ((double)count4 / n) * 100;
            
            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
            
        }
    }
}
