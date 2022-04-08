using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGAmeCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyBoardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int trashedMouse = 0;
            int trushKeyboard = 0;
            int trushDisplay = 0;

            if (lostGAmeCount >= 2)
            {
                int trashedHadeset = lostGAmeCount / 2;

                if (lostGAmeCount >= 3)
                {
                    trashedMouse = lostGAmeCount / 3;
                }
                if (lostGAmeCount >= 6)
                {
                    trushKeyboard = lostGAmeCount / 6;

                }
                if (lostGAmeCount >= 12)
                {
                    trushDisplay = lostGAmeCount / 12;
                }

                double moneyCost = (trashedHadeset * headsetPrice) +
                    (trashedMouse * mousePrice) +
                    (trushKeyboard * keyBoardPrice) +
                    (trushDisplay * displayPrice);

                Console.WriteLine($"Rage expenses: {moneyCost:f2} lv.");
            }
            else
            {
                Console.WriteLine($"Rage expenses: 0 lv.");
            }



        }
    }
}
