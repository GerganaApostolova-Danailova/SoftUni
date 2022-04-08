using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerAndChips
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double bujet = double.Parse(Console.ReadLine());
            int countOfBotelOfBeer = int.Parse(Console.ReadLine());
            int packegeOfChips = int.Parse(Console.ReadLine());

            double beerPrice = countOfBotelOfBeer * 1.20;
            double oneChipsPrice = beerPrice * 0.45;
            double chipsPrice = Math.Ceiling(oneChipsPrice * packegeOfChips);
            double AllSum = chipsPrice + beerPrice;

            if (bujet>= AllSum)
            {
                Console.WriteLine($"{name} bought a snack and has {(bujet-AllSum):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"{name} needs {(AllSum-bujet):f2} more leva!");
            }


        }
    }
}
