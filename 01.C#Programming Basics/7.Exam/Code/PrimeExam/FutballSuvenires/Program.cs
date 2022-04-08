using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutballSuvenires
{
    class Program
    {
        static void Main(string[] args)
        {
            string futballTeamName = Console.ReadLine();
            string souvenirs = Console.ReadLine();
            int NumberOfSuvenirs = int.Parse(Console.ReadLine());

            double AllPrice = 0;

            if (futballTeamName == "Argentina")
            {
                if (souvenirs == "flags")
                {
                    AllPrice = NumberOfSuvenirs * 3.25;
                    Console.WriteLine($"Pepi bought {NumberOfSuvenirs} {souvenirs} of {futballTeamName} for {AllPrice:f2} lv.");
                }
                else if (souvenirs == "caps")
                {
                    AllPrice = NumberOfSuvenirs * 7.20;
                    Console.WriteLine($"Pepi bought {NumberOfSuvenirs} {souvenirs} of {futballTeamName} for {AllPrice:f2} lv.");
                }
                else if (souvenirs == "posters")
                {
                    AllPrice = NumberOfSuvenirs * 5.10;
                    Console.WriteLine($"Pepi bought {NumberOfSuvenirs} {souvenirs} of {futballTeamName} for {AllPrice:f2} lv.");
                }
                else if (souvenirs == "stickers")
                {
                    AllPrice = NumberOfSuvenirs * 1.25;
                    Console.WriteLine($"Pepi bought {NumberOfSuvenirs} {souvenirs} of {futballTeamName} for {AllPrice:f2} lv.");
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                }

            }
            else if (futballTeamName == "Brazil")
            {
                if (souvenirs == "flags")
                {
                    AllPrice = NumberOfSuvenirs * 4.20;
                    Console.WriteLine($"Pepi bought {NumberOfSuvenirs} {souvenirs} of {futballTeamName} for {AllPrice:f2} lv.");
                }
                else if (souvenirs == "caps")
                {
                    AllPrice = NumberOfSuvenirs * 8.50;
                    Console.WriteLine($"Pepi bought {NumberOfSuvenirs} {souvenirs} of {futballTeamName} for {AllPrice:f2} lv.");
                }
                else if (souvenirs == "posters")
                {
                    AllPrice = NumberOfSuvenirs * 5.35;
                    Console.WriteLine($"Pepi bought {NumberOfSuvenirs} {souvenirs} of {futballTeamName} for {AllPrice:f2} lv.");
                }
                else if (souvenirs == "stickers")
                {
                    AllPrice = NumberOfSuvenirs * 1.20;
                    Console.WriteLine($"Pepi bought {NumberOfSuvenirs} {souvenirs} of {futballTeamName} for {AllPrice:f2} lv.");
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                }
            }
            else if (futballTeamName == "Croatia")
            {
                if (souvenirs == "flags")
                {
                    AllPrice = NumberOfSuvenirs * 2.75;
                    Console.WriteLine($"Pepi bought {NumberOfSuvenirs} {souvenirs} of {futballTeamName} for {AllPrice:f2} lv.");
                }
                else if (souvenirs == "caps")
                {
                    AllPrice = NumberOfSuvenirs * 6.90;
                    Console.WriteLine($"Pepi bought {NumberOfSuvenirs} {souvenirs} of {futballTeamName} for {AllPrice:f2} lv.");
                }
                else if (souvenirs == "posters")
                {
                    AllPrice = NumberOfSuvenirs * 4.95;
                    Console.WriteLine($"Pepi bought {NumberOfSuvenirs} {souvenirs} of {futballTeamName} for {AllPrice:f2} lv.");
                }
                else if (souvenirs == "stickers")
                {
                    AllPrice = NumberOfSuvenirs * 1.10;
                    Console.WriteLine($"Pepi bought {NumberOfSuvenirs} {souvenirs} of {futballTeamName} for {AllPrice:f2} lv.");
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                }

            }
            else if (futballTeamName == "Denmark")
            {
                if (souvenirs == "flags")
                {
                    AllPrice = NumberOfSuvenirs * 3.10;
                    Console.WriteLine($"Pepi bought {NumberOfSuvenirs} {souvenirs} of {futballTeamName} for {AllPrice:f2} lv.");
                }
                else if (souvenirs == "caps")
                {
                    AllPrice = NumberOfSuvenirs * 6.50;
                    Console.WriteLine($"Pepi bought {NumberOfSuvenirs} {souvenirs} of {futballTeamName} for {AllPrice:f2} lv.");
                }
                else if (souvenirs == "posters")
                {
                    AllPrice = NumberOfSuvenirs * 4.80;
                    Console.WriteLine($"Pepi bought {NumberOfSuvenirs} {souvenirs} of {futballTeamName} for {AllPrice:f2} lv.");
                }
                else if (souvenirs == "stickers")
                {
                    AllPrice = NumberOfSuvenirs * 0.90;
                    Console.WriteLine($"Pepi bought {NumberOfSuvenirs} {souvenirs} of {futballTeamName} for {AllPrice:f2} lv.");
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                }

            }


            else  //(futballTeamName != "Denmark" || futballTeamName != "Croatia" || futballTeamName != "Brazil" || futballTeamName != "Argentina")*/
            {
                Console.WriteLine("Invalid country!");
            }
            

        }
    }
}
