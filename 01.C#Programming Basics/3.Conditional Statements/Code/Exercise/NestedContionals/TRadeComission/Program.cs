using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRadeComission
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine().ToLower();
            double sealvalue = double.Parse(Console.ReadLine());

            double commission = -1.0;

            if (city == "sofia")
            {
                if (sealvalue >= 0 && sealvalue <= 500)
                {
                    commission = sealvalue * 0.05;
                }
                else if (sealvalue > 500 && sealvalue <= 1000)
                {
                    commission = sealvalue * 0.07;
                }
                else if (sealvalue > 1000 && sealvalue <= 10000)
                {
                    commission = sealvalue * 0.08;
                }
                else if (sealvalue > 10000)
                {
                    commission = sealvalue * 0.12;
                }
                //else
                //{
                //    Console.WriteLine("error");
                //}
                //Console.WriteLine($"{commission:f2}");
            }
            else if (city == "varna")
            {
                if (sealvalue >= 0 && sealvalue <= 500)
                {
                    commission = sealvalue * 0.045;
                }
                else if (sealvalue > 500 && sealvalue <= 1000)
                {
                    commission = sealvalue * 0.075;
                }
                else if (sealvalue > 1000 && sealvalue <= 10000)
                {
                    commission = sealvalue * 0.10;
                }
                else if (sealvalue > 10000)
                {
                    commission = sealvalue * 0.13;
                }
                //else
                //{
                //    Console.WriteLine("error");
                //}
                //Console.WriteLine($"{commission:f2}");
            }
            else if (city == "plovdiv")
            {
                if (sealvalue >= 0 && sealvalue <= 500)
                {
                    commission = sealvalue * 0.055;
                }
                else if (sealvalue > 500 && sealvalue <= 1000)
                {
                    commission = sealvalue * 0.08;
                }
                else if (sealvalue > 1000 && sealvalue <= 10000)
                {
                    commission = sealvalue * 0.12;
                }
                else if (sealvalue > 10000)
                {
                    commission = sealvalue * 0.145;
                }
                ////else
                //{
                //    Console.WriteLine("error");
                //}
                //Console.WriteLine($"{commission:f2}");
            }
            if (commission > -1.0)
            {
                Console.WriteLine($"{commission:f2}");
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
