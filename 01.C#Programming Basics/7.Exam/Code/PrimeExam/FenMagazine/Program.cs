using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FenMagazine
{
    class Program
    {
        static void Main(string[] args)
        {
            int buget = int.Parse(Console.ReadLine());
            int numberOfPredmets = int.Parse(Console.ReadLine());
            int curruntBuget = 0;

            for (int i = 1; i <= numberOfPredmets; i++)
            {
                string predmet = Console.ReadLine();

                if (predmet == "hoodie")
                {
                    curruntBuget += 30;
                }
                else if (predmet == "keychain")
                {
                    curruntBuget += 4;
                }
                else if (predmet == "T-shirt")
                {
                    curruntBuget += 20;
                }
                else if (predmet == "flag")
                {
                    curruntBuget += 15;
                }
                else if (predmet == "sticker")
                {
                    curruntBuget += 1;
                }

            }
            if (curruntBuget <= buget)
            {
                Console.WriteLine($"You bought {numberOfPredmets} items and left with {buget-curruntBuget} lv.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {curruntBuget-buget} more lv.");
            }
        }
    }
}
