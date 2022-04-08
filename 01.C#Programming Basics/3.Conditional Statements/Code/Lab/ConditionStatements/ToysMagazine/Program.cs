using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToysMagazine
{
    class Program
    {
        static void Main(string[] args)
        {
            double PriceOf0Excursion = double.Parse(Console.ReadLine());
            int NumberOfPuzzelsv = int.Parse(Console.ReadLine());
            int NumberOfDoll = int.Parse(Console.ReadLine());
            int NumberOfBear = int.Parse(Console.ReadLine());
            int NumberOfMinions = int.Parse(Console.ReadLine());
            int NumberOfTrucks = int.Parse(Console.ReadLine());
            double PriceOfPuzzels = NumberOfPuzzelsv * 2.60;
            int PriceOfDolls = NumberOfDoll * 3;
            double priceOfBear = NumberOfBear * 4.10;
            double priceofMinions = NumberOfMinions * 8.20;
            int priceOfTrucks = NumberOfTrucks * 2;
            double AllToysNumber = NumberOfTrucks + NumberOfPuzzelsv + NumberOfMinions + NumberOfDoll + NumberOfBear;
            double AllMoneyForToys = priceOfBear + PriceOfDolls + priceofMinions + PriceOfPuzzels + priceOfTrucks;
            double discound = 0.0;
            if (AllToysNumber >= 50)
            {
                discound = AllMoneyForToys * 0.25;

            }
            double TotalPrice = AllMoneyForToys - discound;
            TotalPrice = TotalPrice - (TotalPrice * 0.10);
            if (PriceOf0Excursion <= TotalPrice)
            {
                Console.WriteLine($"Yes! {TotalPrice - PriceOf0Excursion:f2} lv left.");
            }
            else
            {
                Console.WriteLine("Not enough money! {0:f2} lv needed.", Math.Abs(TotalPrice - PriceOf0Excursion));
            }
        }
    }
}
