using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tailoringWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int table = int.Parse(Console.ReadLine());
            Double lenghtTable = Double.Parse(Console.ReadLine());
            Double widthTable = Double.Parse(Console.ReadLine());
            Double Area = table * (lenghtTable + 2 * 0.3) * (widthTable + 2 * 0.3);
            Double SideCare = table * (lenghtTable / 2) * (lenghtTable / 2);
            Double PriceUSD = Area * 7 + SideCare * 9;
            Double Leva = PriceUSD * 1.85;
            Console.WriteLine($"{PriceUSD:F2} USD");
            Console.WriteLine($"{Leva:F2} BGN");
        }
    }
}
