using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsiusToFarenhait
{
    class Program
    {
        static void Main(string[] args)
        {
            double celsios = Double.Parse(Console.ReadLine());
            Double farenhait = (celsios * 9 / 5) + 32;
            Console.WriteLine("{0:F2}", farenhait);
        }
    }
}
