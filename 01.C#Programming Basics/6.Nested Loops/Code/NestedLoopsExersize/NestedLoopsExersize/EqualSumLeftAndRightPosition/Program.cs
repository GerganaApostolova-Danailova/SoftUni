using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualSumLeftAndRightPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int nem1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            for (int i = nem1; i <= num2; i++)
            {
                int dig5 = i % 10;
                int dig4 = i / 10 % 10;
                int dig3 = i / 100 % 10;
                int dig2 = i / 1000 % 10;
                int dig1 = i / 10_000 % 10;

                if (dig5 + dig4 == dig2 + dig1)
                {
                    Console.Write(i + " ");
                }
                else if (dig5 + dig4 > dig2 + dig1)
                {
                    if (dig2 + dig1 + dig3 == dig5 + dig4)
                    {
                        Console.Write(i + " ");
                    }
                }
                else if (dig5 + dig4 < dig2 + dig1)
                {
                    if (dig2 + dig1 == dig5 + dig4 + dig3)
                    {
                        Console.Write(i + " ");
                    }
                }
            }

        }
    }
}
