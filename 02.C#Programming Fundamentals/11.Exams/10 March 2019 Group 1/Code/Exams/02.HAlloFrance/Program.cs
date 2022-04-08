using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.HAlloFrance
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] purch = Console.ReadLine()
                .Split(new char[] { '-', '>', '|' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            double buget = double.Parse(Console.ReadLine());

            double sum = 0;

            List<double> final = new List<double>();

            double priceClothes = 0;
            double priceShoes = 0;
            double priceAccsessoaries = 0;

            double sumAllPrice = 0;

            for (int i = 0; i < purch.Length; i += 2)
            {

                double price = double.Parse(purch[i + 1]);

                if (purch[i] == "Clothes")
                {
                    if (price <= 50.00 && price <= buget)
                    {
                        buget -= price;
                        sum += price;


                        priceClothes = Math.Round((price + (price * 0.4)), 2);

                        final.Add(priceClothes);

                    }
                    else
                    {
                        continue;
                    }
                }

                if (purch[i] == "Shoes")
                {
                    if (price <= 35.00 && price <= buget)
                    {
                        buget -= price;
                        sum += price;

                        priceShoes = Math.Round((price + (price * 0.4)), 2);
                        final.Add(priceShoes);
                    }
                    else
                    {
                        continue;
                    }
                }
                if (purch[i] == "Accessories")
                {
                    if (price <= 20.50 && price <= buget)
                    {
                        buget -= price;
                        sum += price;

                        priceAccsessoaries = Math.Round((price + (price * 0.4)), 2);
                        final.Add(priceAccsessoaries);
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            for (int i = 0; i < final.Count; i++)
            {
                sumAllPrice += final[i];

            }

            double finalWithTicket = sumAllPrice + buget - 150;

            double profit = sum * 0.4;

            if (finalWithTicket >= 0)
            {
                Console.WriteLine(string.Join(" ", final));
                Console.WriteLine($"Profit: {profit:f2}");
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine(string.Join(" ", final));
                Console.WriteLine($"Profit: {profit:f2}");
                Console.WriteLine("Time to go.");
            }
        }
    }
}
