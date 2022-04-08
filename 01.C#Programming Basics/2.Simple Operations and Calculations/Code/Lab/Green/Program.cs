using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Green
{
    class Program
    {
        static void Main(string[] args)
        {
            double scereMeters = double.Parse(Console.ReadLine());

            double AllPriceGreen = scereMeters * 7.61;
            double Sale = AllPriceGreen * 0.18;
            double FinalPrise = AllPriceGreen - Sale;

            Console.WriteLine($"The final price is: {FinalPrise:f2} lv.");
            Console.WriteLine($"The discount is: {Sale:f2} lv.");
        }
    }
}
