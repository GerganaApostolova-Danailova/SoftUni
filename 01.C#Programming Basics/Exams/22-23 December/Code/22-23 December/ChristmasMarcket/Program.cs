using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasMarcket
{
    class Program
    {
        static void Main(string[] args)
        {
            double buget = double.Parse(Console.ReadLine());
            int fentasyBookNumber = int.Parse(Console.ReadLine());
            int horrerBookNumber = int.Parse(Console.ReadLine());
            int romanticBookNumber = int.Parse(Console.ReadLine());

           double priceFantasyBook = fentasyBookNumber * 14.90;
           double pricehorrerBook = horrerBookNumber * 9.80;
            double priceromanticBook = romanticBookNumber * 4.30;

            double AllPrice = priceFantasyBook + pricehorrerBook + priceromanticBook;
            double DDS = AllPrice * 0.20;
            double allPriceDDS = AllPrice - DDS;

            if (allPriceDDS > buget)
            {
                double target = allPriceDDS - buget;
                double ForHuman =Math.Floor( target * 0.10);
                double MOneyForDonate = target - ForHuman;
                double Donate = buget + MOneyForDonate;
                Console.WriteLine($"{Donate:f2} leva donated.");
                Console.WriteLine($"Sellers will receive {ForHuman} leva.");
            }
            else
            {
                double needMoney = buget - allPriceDDS;
                Console.WriteLine($"{needMoney:f2} money needed.");
            }
        }
    }
}
