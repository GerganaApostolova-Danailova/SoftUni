using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberGosts = int.Parse(Console.ReadLine());
            double priceForOnePerson = double.Parse(Console.ReadLine());
            double bujetOfDesi = double.Parse(Console.ReadLine());

            double priceCake = bujetOfDesi * 0.10;
            double AllPrice = 0;


            if (numberGosts >= 10 && numberGosts <= 15)
            {
                double saleForOnePerso = priceForOnePerson - (priceForOnePerson * 0.15);
                AllPrice = (numberGosts * saleForOnePerso) + priceCake;
            }
            else if (numberGosts > 15 && numberGosts <= 20)
            {
                double saleForOnePerso = priceForOnePerson - (priceForOnePerson * 0.20);
                AllPrice = (numberGosts * saleForOnePerso) + priceCake;
            }
            else if (numberGosts > 20)
            {
                double saleForOnePerso = priceForOnePerson - (priceForOnePerson * 0.25);
                AllPrice = (numberGosts * saleForOnePerso) + priceCake;
            }
            else if (numberGosts < 10)
            {
                double saleForOnePerso = priceForOnePerson;
                AllPrice = (numberGosts * saleForOnePerso) + priceCake;
            }
            if (AllPrice <= bujetOfDesi)
            {
                Console.WriteLine($"It is party time! {(bujetOfDesi - AllPrice):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"No party! {(AllPrice - bujetOfDesi):f2} leva needed.");
            }
        }
    }
}
