using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberCake = int.Parse(Console.ReadLine());
            int numberEgg = int.Parse(Console.ReadLine());
            int numberCurabies = int.Parse(Console.ReadLine());

            double priceCake = numberCake * 3.20;
            double priceEggs = numberEgg * 4.35;
            double priceCurabies = numberCurabies * 5.40;
            double priceBoq = numberEgg * 12 * 0.15;
            double AllPrice = priceCake + priceEggs + priceCurabies + priceBoq;

            Console.WriteLine($"{AllPrice:f2}");

        }
    }
}
