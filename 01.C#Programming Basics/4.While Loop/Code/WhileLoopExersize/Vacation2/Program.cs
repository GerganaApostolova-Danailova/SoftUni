using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation2
{
    class Program
    {
        static void Main(string[] args)
        {



            double moneyNeeded = double.Parse(Console.ReadLine());
            double ourMoney = double.Parse(Console.ReadLine());
            int counter = 0;
            int spendCounter = 0;

            while (ourMoney < moneyNeeded)
            {
                string command = Console.ReadLine();
                if (command == "spend")
                {
                    ourMoney -= double.Parse(Console.ReadLine());
                    if (ourMoney < 0)
                    {
                        ourMoney = 0;
                    }
                    counter++;
                    spendCounter++;
                    if (spendCounter >= 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine(counter);
                        break;
                    }
                }
                else if (command == "save")
                {
                    ourMoney += double.Parse(Console.ReadLine());
                    counter++;
                    spendCounter = 0;
                }
            }

            if (spendCounter < 5)
            {
                Console.WriteLine("You saved the money for {0} days.", counter);
            }

        }
    }
}
