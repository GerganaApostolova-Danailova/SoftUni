using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            
            

            while (destination != "End")
            {
                double budget = double.Parse(Console.ReadLine());
                double saveMoney = 0;

                while (saveMoney< budget)
                {
                    double money = double.Parse(Console.ReadLine());
                    saveMoney += money;
                   
                }

                Console.WriteLine($"Going to {destination}!");
                saveMoney = 0;
                destination = Console.ReadLine();
                

            }
            


        }
    }
}
