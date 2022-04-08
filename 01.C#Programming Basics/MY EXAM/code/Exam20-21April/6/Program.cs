using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfClient = int.Parse(Console.ReadLine());

            string command = string.Empty;
            int counterProduct = 0;
            double price = 0;
            double SecondPrice = 0;
            double AveragePrice = 0;

            for (int i = 0; i < numberOfClient; i++)
            {

                while ((command = Console.ReadLine()) != "Finish")
                {
                    if (command == "basket")
                    {
                        price += 1.50;
                        counterProduct++;
                    }
                    else if (command == "wreath")
                    {
                        price += 3.80;
                        counterProduct++;
                    }
                    else if (command == "chocolate bunny")
                    {
                        price += 7.00;
                        counterProduct++;
                    }
                }

                if (counterProduct % 2 == 0)
                {
                    price = price - (price * 0.20);
                    SecondPrice += price;
                }
                else
                {
                    SecondPrice += price;
                }

                if (command == "Finish")
                {
                    if (counterProduct % 2 == 0)
                    {
                        Console.WriteLine($"You purchased {counterProduct} items for {price:f2} leva.");
                    }
                    else
                    {
                        Console.WriteLine($"You purchased {counterProduct} items for {price:f2} leva.");
                    }
                    counterProduct = 0;
                    price = 0;
                }
            }
            
                AveragePrice = SecondPrice / numberOfClient;
                Console.WriteLine($"Average bill per client is: {AveragePrice:f2} leva.");
        }
    }
}
