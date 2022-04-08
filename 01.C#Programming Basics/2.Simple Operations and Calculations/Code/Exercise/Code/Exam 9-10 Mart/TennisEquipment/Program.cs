using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisEquipmentd
{
    class Program
    {
        static void Main(string[] args)
        {
            double PriceRacket = double.Parse(Console.ReadLine());
            int NumberRacket = int.Parse(Console.ReadLine());
            int NumberShoes = int.Parse(Console.ReadLine());
            double PriceAllRackets = NumberRacket * PriceRacket;
            //Console.WriteLine(PriceAllRackets);
            double PriceShoes = PriceRacket / 6;
            //Console.WriteLine(PriceShoes);
            double PriceAllShoes = NumberShoes * PriceShoes;
            //Console.WriteLine(PriceAllShoes);
            double PriceEquipments = (PriceAllRackets + PriceAllShoes) * 0.2;
            //Console.WriteLine(PriceEquipments);
            double AllPrice = PriceAllRackets + PriceAllShoes + PriceEquipments;
            //Console.WriteLine(AllPrice);
            double PriceForDjokovich = Math.Floor(AllPrice / 8);
            double PriceForSponsors = Math.Ceiling(AllPrice * 0.875);
            Console.WriteLine($"Price to be paid by Djokovic {PriceForDjokovich}");
            Console.WriteLine($"Price to be paid by sponsors {PriceForSponsors}");
        }
    }
}
