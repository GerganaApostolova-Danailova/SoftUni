using System;
using System.Collections.Generic;
using System.Linq;


namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops = new SortedDictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string[] line = Console.ReadLine()
                    .Split(", ");

                if (line[0] == "Revision")
                {
                    break;
                }

                string shop = line[0];
                string product = line[1];
                double price = double.Parse(line[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }
                if (!shops[shop].ContainsKey(product))
                {
                    shops[shop].Add(product, 0);
                }
                shops[shop][product] = price;
            }

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var kvp in shop.Value)
                {
                    Console.WriteLine($"Product: {kvp.Key}, Price: {kvp.Value}");
                }
            }
        }
    }
}
