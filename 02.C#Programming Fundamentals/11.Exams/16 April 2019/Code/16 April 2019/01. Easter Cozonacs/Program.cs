using System;

namespace _01._Easter_Cozonacs
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double florePriceKg = double.Parse(Console.ReadLine());

            double eggsPriceForPackeg = florePriceKg * 0.75;
            double milkPriceLitre = florePriceKg + (florePriceKg * 0.25);

            double cozonacPrice = florePriceKg + eggsPriceForPackeg + (milkPriceLitre / 4);
            int cozonacsCounter = 0;
            int colourEggsCounter = 0;

            while (budget >= cozonacPrice)
            {
                cozonacsCounter++;
                budget -= cozonacPrice;
                colourEggsCounter += 3;

                if (cozonacsCounter % 3 == 0)
                {
                    colourEggsCounter -= cozonacsCounter - 2;
                }
            }

            Console.WriteLine($"You made {cozonacsCounter} cozonacs! Now you have {colourEggsCounter} eggs and {budget:f2}BGN left.");
        }
    }
}
