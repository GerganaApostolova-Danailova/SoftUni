using System;

namespace _7._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {

            string command = string.Empty;

            double bujet = 0;

            while ((command = Console.ReadLine()) != "Start")
            {
                double coins = double.Parse(command);

                if (coins == 0.1 || coins == 0.2 || coins == 0.5|| coins == 1 || coins == 2)
                {
                    bujet += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }
            }

            while ((command = Console.ReadLine()) != "End")
                {

                if (command== "Nuts")
                {
                    if (bujet<2.0)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        continue;
                    }
                    else
                    {
                        bujet -= 2.0;
                        Console.WriteLine("Purchased nuts");
                    }
                    
                }

                else if (command == "Water")
                {
                    if (bujet < 0.7)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        continue;
                    }
                    else
                    {
                        bujet -= 0.7;
                        Console.WriteLine("Purchased water");
                    }
                }
                else if (command == "Crisps")
                {
                    if (bujet < 1.5)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        continue;
                    }
                    else
                    {
                        bujet -= 1.5;
                        Console.WriteLine("Purchased crisps");
                    }
                }
                else if (command == "Soda")
                {
                    if (bujet < 0.8)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        continue;
                    }
                    else
                    {
                        bujet -= 0.8;
                        Console.WriteLine("Purchased soda");
                    }
                }
                else if (command == "Coke")
                {
                    if (bujet < 1.0)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        continue;
                    }
                    else
                    {
                        bujet -= 1.0;
                        Console.WriteLine("Purchased coke");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
               
            }
            
            
            if (command == "End")
            {
                Console.WriteLine($"Change: {bujet:f2}");
            }
        }
    }
}
