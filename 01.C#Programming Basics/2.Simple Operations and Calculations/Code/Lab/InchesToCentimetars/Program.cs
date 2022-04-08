using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InchesToCentimetars
{
    class Program
    {
        static void Main(string[] args)
        {
            Double inches = Double.Parse(Console.ReadLine());
            double sentimaters = inches * 2.54;
            Console.WriteLine($"{sentimaters:F2}");
        }
    }
}
