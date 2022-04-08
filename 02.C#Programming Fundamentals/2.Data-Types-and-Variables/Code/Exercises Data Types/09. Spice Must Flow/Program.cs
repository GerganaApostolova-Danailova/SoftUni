using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int production = int.Parse(Console.ReadLine());

            int dayCount = 0;
            int forWorker = 26;
            int productForDays = 0;

            while (production >= 100)
            {
                dayCount++;
                productForDays += production - forWorker;
                production = production - 10;

                if (production < 100)
                {
                    productForDays = productForDays - forWorker;
                }
              
            }
            

            Console.WriteLine(dayCount);
            Console.WriteLine(productForDays);
        }
    }
}
