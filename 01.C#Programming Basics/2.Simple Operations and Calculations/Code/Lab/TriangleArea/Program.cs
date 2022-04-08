using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = Double.Parse(Console.ReadLine());
            double h = Double.Parse(Console.ReadLine());
            double area = a * h / 2;
            Console.WriteLine("{0:F2}", area);
        }
    }
}
