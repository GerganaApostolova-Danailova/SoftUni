using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string productName = Console.ReadLine();
            string CityNAme = Console.ReadLine();
            double Quantity = double.Parse(Console.ReadLine());

            double price = 0;

            if (CityNAme == "Sofia")
            {
                if (productName == "coffee")
                {
                    price = Quantity * 0.50;
                    Console.WriteLine(price);
                }
                else if (productName == "water")
                {
                    price = Quantity * 0.80;
                    Console.WriteLine(price);
                }
                else if (productName == "beer")
                {
                    price = Quantity * 1.20;
                    Console.WriteLine(price);
                }
                else if (productName == "sweets")
                {
                    price = Quantity * 1.45;
                    Console.WriteLine(price);
                }
                else if (productName == "peanuts")
                {
                    price = Quantity * 1.60;
                    Console.WriteLine(price);
                }
            }
                if (CityNAme == "Plovdiv")
                {
                    if (productName == "coffee")
                    {
                        price = Quantity * 0.40;
                        Console.WriteLine(price);
                    }
                    else if (productName == "water")
                    {
                        price = Quantity * 0.70;
                        Console.WriteLine(price);
                    }
                    else if (productName == "beer")
                    {
                        price = Quantity * 1.15;
                        Console.WriteLine(price);
                    }
                    else if (productName == "sweets")
                    {
                        price = Quantity * 1.30;
                        Console.WriteLine(price);
                    }
                    else if (productName == "peanuts")
                    {
                        price = Quantity * 1.50;
                        Console.WriteLine(price);
                    }
                }
                    if (CityNAme == "Varna")
                    {
                        if (productName == "coffee")
                        {
                            price = Quantity * 0.45;
                            Console.WriteLine(price);
                        }
                        else if (productName == "water")
                        {
                            price = Quantity * 0.70;
                            Console.WriteLine(price);
                        }
                        else if (productName == "beer")
                        {
                            price = Quantity * 1.10;
                            Console.WriteLine(price);
                        }
                        else if (productName == "sweets")
                        {
                            price = Quantity * 1.35;
                            Console.WriteLine(price);
                        }
                        else if (productName == "peanuts")
                        {
                            price = Quantity * 1.55;
                            Console.WriteLine(price);
                        }
                    }


                
            
        }
    }
}
