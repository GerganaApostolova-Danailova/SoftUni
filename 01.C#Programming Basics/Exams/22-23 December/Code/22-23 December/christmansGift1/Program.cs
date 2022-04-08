using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace christmansGift1
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            //int age = int.Parse(Console.ReadLine());
            int countAdult = 0;
            int coundKids = 0;
            double PriceToys = 0.0;
            double PriceSweeters = 0.0;
           

            while ((command = Console.ReadLine()) != "Christmas")
            {
                  int age = int.Parse(command);

                if ( age <= 16)
                {
                    PriceToys += 5;
                    coundKids++;
                }
                else if (age > 16)
                {
                    PriceSweeters += 15;
                    countAdult++;
                }
                
            }


            if (command == "Christmas")
            {
                Console.WriteLine($"Number of adults: {countAdult}");
                Console.WriteLine($"Number of kids: {coundKids}");
                Console.WriteLine($"Money for toys: {PriceToys}");
                Console.WriteLine($"Money for sweaters: {PriceSweeters}");
            }
        }
    }
}
