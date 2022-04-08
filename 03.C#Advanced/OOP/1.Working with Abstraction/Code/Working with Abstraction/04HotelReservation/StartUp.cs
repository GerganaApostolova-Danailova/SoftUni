using System;
using System.Linq;

namespace _04HotelReservation
{
    public class StartUp
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            decimal pricePerDay = decimal.Parse(input[0]);
            int numberOfDays = int.Parse(input[1]);
            string season = input[2].ToLower();
            string discountType = "none";

            if (input.Length > 3)
            {
                discountType = input[3].ToLower();
            }

            decimal totalPrice = PriceCalculator.CalculatePrice(pricePerDay,
                numberOfDays,
                Enum.Parse<Season>(season),
                Enum.Parse<Discount>(discountType));

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
