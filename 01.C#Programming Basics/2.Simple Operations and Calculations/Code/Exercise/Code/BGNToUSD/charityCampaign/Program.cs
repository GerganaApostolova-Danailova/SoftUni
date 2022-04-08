using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int DaysofCharity = int.Parse(Console.ReadLine());
            int Beikers = int.Parse(Console.ReadLine());
            int NumberOfCake = int.Parse(Console.ReadLine());
            int NumberOfWafer = int.Parse(Console.ReadLine());
            int NumberOfPancake = int.Parse(Console.ReadLine());
            int PriceOfCake = NumberOfCake * 45;
            Double PriceOfWafer = NumberOfWafer * 5.80;
            Double PriceOfPanecake = NumberOfPancake * 3.20;
            Double CakeOfBeiker = Beikers * (PriceOfCake + PriceOfPanecake + PriceOfWafer);
            Double AllDayOfCakes = CakeOfBeiker * DaysofCharity;
            Double PeaceOfPrice = AllDayOfCakes - (AllDayOfCakes * 1 / 8);
            Console.WriteLine($"{PeaceOfPrice:F2}");
        }
    }
}
