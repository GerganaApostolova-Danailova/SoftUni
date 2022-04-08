using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastryShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string cake = Console.ReadLine();
            int numberOfOrders = int.Parse(Console.ReadLine());
            int dayFromDecember = int.Parse(Console.ReadLine());
            double price = 0;

            if (dayFromDecember <= 22)
            {
                if (dayFromDecember <= 15)
                {
                    if (cake == "Cake")
                    {
                        price = numberOfOrders * 24.00 - ((numberOfOrders * 24.00) * 0.1);

                    }
                    else if (cake == "Souffle")
                    {
                        price = numberOfOrders * 6.66 - ((numberOfOrders * 6.66) * 0.1);
                    }
                    else if (cake == "Baklava")
                    {
                        price = numberOfOrders * 12.60 - ((numberOfOrders * 12.60) * 0.1);
                    }
                }
                else if (dayFromDecember > 15)
                {
                    if (cake == "Cake")
                    {
                        price = numberOfOrders * 28.70;

                    }
                    else if (cake == "Souffle")
                    {
                        price = numberOfOrders * 9.80;
                    }
                    else if (cake == "Baklava")
                    {
                        price = numberOfOrders * 16.98;
                    }
                }
                if (price >=100 && price <= 200)
                {
                    price = price - (price * 0.15);
                    Console.WriteLine($"{price:f2}");
                }
                else if (price > 200)
                {
                    price = price - (price * 0.25);
                    Console.WriteLine($"{price:f2}");
                }
                else
                {
                    Console.WriteLine($"{price:f2}");
                }
            }
            else if (dayFromDecember > 22)
            {
                if (cake == "Cake")
                {
                    price = numberOfOrders * 28.70;

                }
                else if (cake == "Souffle")
                {
                    price = numberOfOrders * 9.80;
                }
                else if (cake == "Baklava")
                {
                    price = numberOfOrders * 16.98;
                }
                Console.WriteLine($"{price:f2}");

            }
        }
    }
}
