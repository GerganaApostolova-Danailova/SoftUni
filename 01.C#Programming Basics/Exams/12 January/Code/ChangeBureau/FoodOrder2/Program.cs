using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder2
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            string command = string.Empty;


            int coundStock = 0;
            int unCoundStock = 0;
            double totalPrice = 2.5;


            while ((command = Console.ReadLine()) != "Order")
            {
                double priceStock = double.Parse(Console.ReadLine());
                
                if (totalPrice <= budget)
                {
                    totalPrice += priceStock;

                    coundStock++;

                }
                 if (totalPrice > budget)
                {
                    totalPrice -= priceStock;
                    unCoundStock++;
                    coundStock--;
                    // command = Console.ReadLine();
                 //  priceStock = double.Parse(Console.ReadLine());
                 //  totalPrice += priceStock;
                  //  if (totalPrice <= budget)
                  //  {

                     //   coundStock++;
                  //  }


                }

            }
            if (command == "Order")
            {

                while (unCoundStock != 0)
                {

                    Console.WriteLine("You will exceed the budget if you order this!");
                    unCoundStock--;

                }

                if (totalPrice <= budget)
                {
                    Console.WriteLine($"You ordered {coundStock} items!");
                    Console.WriteLine($"Total: {totalPrice:f2}");
                }



            }
        }
    }
}
