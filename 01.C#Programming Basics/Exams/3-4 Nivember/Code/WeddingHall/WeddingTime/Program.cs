using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingTime
{
    class Program
    {
        static void Main(string[] args)
        {
            double WiskeyPrice = double.Parse(Console.ReadLine());
            double LiterOfWater = double.Parse(Console.ReadLine());
            double LiterOfWine = double.Parse(Console.ReadLine());
            double LiterOfShampein = double.Parse(Console.ReadLine());
            double LitersOfWiskey = double.Parse(Console.ReadLine());
            double AllWiskeyPrice = WiskeyPrice * LitersOfWiskey;
            double ShampainPrice = WiskeyPrice * 0.5;
            double WinePrice = ShampainPrice * 0.4;
            double WaterPrice = ShampainPrice * 0.1;
            double AllShampainPrice = ShampainPrice * LiterOfShampein;
            double AllWaterPrice = WaterPrice * LiterOfWater;
            double AllWinePrice = WinePrice * LiterOfWine;
            double AllAlcoholPrice = AllShampainPrice + AllWaterPrice + AllWinePrice + AllWiskeyPrice;
            Console.WriteLine($"{AllAlcoholPrice:F2}");
                 

        }
    }
}
