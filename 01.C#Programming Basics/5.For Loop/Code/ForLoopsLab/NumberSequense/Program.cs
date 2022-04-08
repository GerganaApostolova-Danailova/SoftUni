using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSequense
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int biggeste = int.MinValue;
            int smallest = int.MaxValue;

            for (int i=0; i <n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num > biggeste)
                {
                    biggeste=num;
                }
                if (num < smallest)
                {
                    smallest=num;
                }
            }

            Console.WriteLine($"Max number: {biggeste}");
            Console.WriteLine($"Min number: {smallest}");
        }
    }
}
