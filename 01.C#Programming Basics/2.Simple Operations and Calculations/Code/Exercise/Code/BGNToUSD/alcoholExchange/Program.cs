using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alcoholExchange
{
    class Program
    {
        static void Main(string[] args)
        {
            double PriceWeskey = double.Parse(Console.ReadLine());
            double litersbeer = double.Parse(Console.ReadLine());
            double literswine = double.Parse(Console.ReadLine());
            double litersrakia = double.Parse(Console.ReadLine());
            double litersweskey = double.Parse(Console.ReadLine());
            double priceRakia = PriceWeskey / 2;
            double priceWine = priceRakia - (0.4 * priceRakia);
            double priceBeer = priceRakia - (0.8 * priceRakia);
            double sumRakia = priceRakia * litersrakia;
            double sumwine = priceWine * literswine;
            double sumbeer = priceBeer * litersbeer;
            double sumweskey = PriceWeskey * litersweskey;
            double AlcoholPrice = sumweskey + sumRakia + sumwine + sumbeer;
            Console.WriteLine($"{AlcoholPrice:F2}");
        }
    }
}
