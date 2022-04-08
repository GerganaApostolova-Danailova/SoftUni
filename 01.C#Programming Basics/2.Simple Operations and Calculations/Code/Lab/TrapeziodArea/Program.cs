using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrapeziodArea
{
    class Program
    { 
        static void Main(string[] args)
        {
            Double a = Double.Parse(Console.ReadLine());
            Double b = Double.Parse(Console.ReadLine());
            Double h = Double.Parse(Console.ReadLine());
            Double Area = (a + b) / 2 * h;
        Console.WriteLine($"{Area:F2}");
        }
    }
}
