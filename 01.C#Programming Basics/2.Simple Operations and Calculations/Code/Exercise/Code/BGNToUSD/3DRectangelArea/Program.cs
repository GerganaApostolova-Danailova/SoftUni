using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DRectangelArea
{
    class Program
    {
        static void Main(string[] args)
        {
            Double x1 = Double.Parse(Console.ReadLine());
            Double y1 = Double.Parse(Console.ReadLine());
            Double x2 = Double.Parse(Console.ReadLine());
            Double y2 = Double.Parse(Console.ReadLine());
            Double sideOne = Math.Abs(x1 - x2);
            Double sideTwo = Math.Abs(y1 - y2);
            Double Area = sideOne * sideTwo;
            Double Perimetar = 2 * (sideOne + sideTwo);
            Console.WriteLine($"{Area:F2}");
            Console.WriteLine($"{Perimetar:F2}");
            
         }
    }
}
