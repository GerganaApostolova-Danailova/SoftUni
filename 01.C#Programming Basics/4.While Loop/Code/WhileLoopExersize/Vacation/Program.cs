using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double needMoney = double.Parse(Console.ReadLine());
            double currentBalanse = double.Parse(Console.ReadLine());

            double dayscound = 0;
            double spendDaysCound = 0;

            while (currentBalanse < needMoney) ;
            {
              
                string commend = Console.ReadLine();
                double dailyMoney = double.Parse(Console.ReadLine());

                dayscound++;

                if (commend == "spend")
                {
                    currentBalanse -= dailyMoney;
                    if ( currentBalanse < 0)
                    {
                        currentBalanse = 0;
                    }
                    spendDaysCound++;

                    if (spendDaysCound == 5)
                    {
                        break;

                    }
                }
                else if (commend == "save")
                {
                    currentBalanse += dailyMoney;
                    spendDaysCound = 0;

                }

            }
            if (currentBalanse >= needMoney)
            {
                Console.WriteLine($"You saved the money for {dayscound} days");
            }
            else if (spendDaysCound >= 5) ;
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(dayscound);
            }

        }
    }
}
