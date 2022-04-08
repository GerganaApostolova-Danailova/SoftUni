using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadianToDegries
{
    class Program
    {
        static void Main(string[] args)
        {
            Double Radians = Double.Parse(Console.ReadLine());
            double Degries = Radians * 180 / Math.PI;
            Console.WriteLine(Math.Round(Degries));
        }
    }
}
