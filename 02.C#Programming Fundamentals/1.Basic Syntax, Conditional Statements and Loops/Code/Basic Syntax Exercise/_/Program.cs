using System;

namespace _
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfpeople = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string dayOfweek = Console.ReadLine();
            double price = 0;
            if (groupType == "Students")
            {
                switch (dayOfweek)
                {
                    case "Friday": price = 8.45; ; break;
                    case "Saturday": price = 9.80; break;
                    case "Sunday": price = 10.46; break;
                    default:
                        break;
                }

            }
            else if (groupType == "Business")
            {
                switch (dayOfweek)
                {
                    case "Friday": price = 10.90; ; break;
                    case "Saturday": price = 15.60; break;
                    case "Sunday": price = 16.00; break;
                    default:
                        break;
                }

            }
            else if (groupType == "Regular")
            {
                switch (dayOfweek)
                {
                    case "Friday": price = 15.00; break;
                    case "Saturday": price = 20.00; break;
                    case "Sunday": price = 22.50; break;
                    default:
                        break;
                }

            }
            if (groupType == "Students" && numberOfpeople >= 30)
            {
                price = price * numberOfpeople * 0.85;
            }
            else if (groupType == "Business" && numberOfpeople >= 100)
            {
                price = price * (numberOfpeople - 10);
            }
            else if (groupType == "Regular" && numberOfpeople >= 10 && numberOfpeople <= 20)
            {
                price = price * numberOfpeople * 0.95;

            }
            else
            {
                price *= numberOfpeople;
            }
            Console.WriteLine($"Total price: {price:f2}");
        }
    }
}
