using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing
{
    class Program
    {
        static void Main(string[] args)
        {
            int quota = int.Parse(Console.ReadLine());

            string catname = string.Empty;
            
            int counter = 0;
            double sumForTake = 0;
            double sumToSpend = 0;


           
            while ((catname = Console.ReadLine()) != "Stop")
            {
                counter++;
                double fishWeight = double.Parse(Console.ReadLine());

                double price = 0;
                double priceForOneFish = 0;

                for (int i = 0; i < catname.Length; i++)
                {
                    price += catname[i];
                }

                priceForOneFish = price / fishWeight;

                if (counter % 3 == 0)
                {
                    sumForTake += priceForOneFish;
                }

                else
                {
                   sumToSpend += priceForOneFish;

                }
                if (counter >= quota)
                {
                    Console.WriteLine($"Lyubo fulfilled the quota!");                                       
                    break;

                }

            }
                       
                if (sumForTake > sumToSpend)
                {
                    Console.WriteLine($"Lyubo's profit from {counter} fishes is {(sumForTake - sumToSpend):f2} leva.");

                }
                else
                {
                    Console.WriteLine($"Lyubo lost {(sumToSpend - sumForTake):f2} leva today.");
                }
            
        }
    }
}
