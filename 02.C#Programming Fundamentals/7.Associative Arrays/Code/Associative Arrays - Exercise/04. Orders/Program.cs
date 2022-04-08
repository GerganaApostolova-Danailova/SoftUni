using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> products = new Dictionary<string, List<double>>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "buy")
                {
                    break;
                }

                string[] currentProduct = line.Split();

                string name = currentProduct[0];
                double price = double.Parse(currentProduct[1]);
                int quantity = int.Parse(currentProduct[2]);


                if (!products.ContainsKey(name))
                {
                    
                    products.Add(name, new List<double>());

                    products[name].Add(price);
                    products[name].Add(quantity);

                }
                else
                {
                    double newPrice = products[name][0];
                   
                    if (newPrice != price)
                    {
                        products[name][0] = price;
                       
                    }

                    products[name][1] += quantity;
                }
                

            }

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key} -> {((product.Value[0])* (product.Value[1])):f2}");
            }
        }
    }
}
