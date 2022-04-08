using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiVacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double dayForStay = double.Parse(Console.ReadLine());
            string variablestay = Console.ReadLine();
            string rating = Console.ReadLine();

            double nightToSleep = dayForStay - 1.0;
            double priceForStay = 0.0;
            double priceforonePersonRoom = nightToSleep * 18.0;
            double priceForApartment = nightToSleep * 25.0;
            double priceForPresidntRoom = nightToSleep * 35.0;


            if (variablestay == "room for one person")
            {
                if (nightToSleep < 10)
                {
                    priceForStay = priceforonePersonRoom;
                }
                else if (nightToSleep >=10 && nightToSleep <= 15)
                {
                    priceForStay = priceforonePersonRoom;
                }
                else if (nightToSleep > 15)
                {
                    priceForStay = priceforonePersonRoom;
                }
            }
            else if (variablestay == "apartment")
            {
                if (nightToSleep < 10)
                {
                    priceForStay = priceForApartment - (priceForApartment * 0.30);
                }
                else if (nightToSleep >= 10 && nightToSleep <= 15)
                {
                    priceForStay = priceForApartment - (priceForApartment * 0.35);
                }
                else if (nightToSleep > 15)
                {
                    priceForStay = priceForApartment - (priceForApartment * 0.50);
                }
            }
            else if (variablestay == "president apartment")
            {
                if (nightToSleep < 10)
                {
                    priceForStay = priceForPresidntRoom - (priceForPresidntRoom * 0.10);
                }
                else if (nightToSleep >= 10 && nightToSleep <= 15)
                {
                    priceForStay = priceForPresidntRoom - (priceForPresidntRoom* 0.15);
                }
                else if (nightToSleep > 15)
                {
                    priceForStay = priceForPresidntRoom - (priceForPresidntRoom * 0.20);
                }
            }
            if (rating == "positive")
            {
                Console.WriteLine($"{(priceForStay * 1.25):f2}");
            }
            else if (rating == "negative")
            {
                Console.WriteLine($"{(priceForStay - (priceForStay * 0.10)):f2}");
            }
        }
    }
}
