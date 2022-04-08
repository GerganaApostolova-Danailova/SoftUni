using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string dates = Console.ReadLine();
            int numberNights = int.Parse(Console.ReadLine());

            double AllpriceNight = 0;

            if (destination == "France")
            {
                if (dates == "21-23")
                {
                    AllpriceNight = 30 * numberNights;
                }
                else if (dates == "24-27")
                {
                    AllpriceNight = 35 * numberNights;
                }
                else if (dates == "28-31")
                {
                    AllpriceNight = 40 * numberNights;
                }
            }
            else if (destination == "Italy")
            {
                if (dates == "21-23")
                {
                    AllpriceNight = 28 * numberNights;
                }
                else if (dates == "24-27")
                {
                    AllpriceNight = 32 * numberNights;
                }
                else if (dates == "28-31")
                {
                    AllpriceNight = 39 * numberNights;
                }
            }
            else if (destination == "Germany")
            {
                if (dates == "21-23")
                {
                    AllpriceNight = 32 * numberNights;
                }
                else if (dates == "24-27")
                {
                    AllpriceNight = 37 * numberNights;
                }
                else if (dates == "28-31")
                {
                    AllpriceNight = 43 * numberNights;
                }
            }
            Console.WriteLine($"Easter trip to {destination} : {AllpriceNight:f2} leva.");
        }
    }
}
