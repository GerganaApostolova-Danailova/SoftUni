using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxNUmber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int counter = 0;
            double max = int.MinValue;

            while (counter < n)
            {
                double num = double.Parse(Console.ReadLine());
                counter++;

                if (num > max)
                {
                    max = num;
                }
               // Console.WriteLine(max);
            }
            Console.WriteLine(max);

        }
    }
}
