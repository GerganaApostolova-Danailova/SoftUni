using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGNToUSD
{
    class Program
    {
        static void Main(string[] args)
        {
            Double USD = double.Parse(Console.ReadLine());
            Double BGN = USD * 1.79549;
            Console.WriteLine($"{BGN:F2}");

        }
    }
}
