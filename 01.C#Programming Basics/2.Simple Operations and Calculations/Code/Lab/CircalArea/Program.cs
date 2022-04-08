using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircalArea
{
    class Program
    {
        static void Main(string[] args)
        {
            Double r = Double.Parse(Console.ReadLine());
            double area = Math.PI * r * r;
            double perimatur = 2 * Math.PI * r;
            Console.WriteLine("{0:F2}",area);
            Console.WriteLine("{0:F2}", perimatur);
        }
    }
}
