using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {

            List<IBuyer> buyers = new List<IBuyer>();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] bayer = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (bayer.Length == 4)
                {
                    Citizen citizen = new Citizen(bayer[0],int.Parse(bayer[1]), bayer[2], bayer[0]);

                    buyers.Add(citizen);
                }
                else if (bayer.Length == 3)
                {
                    Rebel rebel = new Rebel(bayer[0], int.Parse(bayer[1]), bayer[2]);

                    buyers.Add(rebel);
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                var buyer = buyers.FirstOrDefault(b => b.Name == command);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
              
            }

            Console.WriteLine(buyers.Sum(b => b.Food));
            
        }
    }
}
