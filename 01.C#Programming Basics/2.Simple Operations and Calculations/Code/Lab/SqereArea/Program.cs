using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqereArea
{
    class Program
    {
        static void Main(string[] args)
        {
            Double sqareSide = Double.Parse(Console.ReadLine());
            double sqearArea = sqareSide * sqareSide;
            Console.WriteLine(sqearArea);
            
        }
    }
}
