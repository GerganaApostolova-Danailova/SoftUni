using System;

namespace _01._Spring_Vacation_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfTrip = int.Parse(Console.ReadLine());
            double bujet = double.Parse(Console.ReadLine());
            int numberOfPeople = int.Parse(Console.ReadLine());
            double priceOfFuel = double.Parse(Console.ReadLine());
            double MoneyFoodForDay = double.Parse(Console.ReadLine());
            double priceForRoom = double.Parse(Console.ReadLine());
            

            if (numberOfPeople > 10)
            {
                priceForRoom *= 0.75;
            }

            double currentExpences = daysOfTrip * numberOfPeople * (MoneyFoodForDay + priceForRoom);

            for (int i = 1; i <= daysOfTrip; i++)
            {
                int distance = int.Parse(Console.ReadLine());

                currentExpences += distance * priceOfFuel;
                

                if (i % 3 == 0 || i % 5 == 0 )
                {
                    currentExpences *= 1.4;
                }
                if (i % 7 == 0)
                {
                    currentExpences -= currentExpences / numberOfPeople;
                   
                }
                if (currentExpences > bujet)
                {
                    Console.WriteLine($"Not enough money to continue the trip. You need {(currentExpences - bujet):f2}$ more.");
                    return;
                }

            }

            Console.WriteLine($"You have reached the destination. You have {(bujet - currentExpences):f2}$ budget left.");


        }
    }
}
