using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int tab = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());
            


            for (int i=0; i<tab; i++)
            {
                string site = Console.ReadLine();

                if ( site == "Facebook")
                {
                    salary -= 150;
                }
                else if(site == "Instagram")
                {
                    salary -= 100;
                }
                else if (site == "Reddit")
                {
                    salary -= 50;
                }
                else
                {
                    salary -= 0;
                }
                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    i = tab;
                }
                
            }
            if (salary > 0)
            {
                Console.WriteLine((int)salary);
            }
        }
    }
}
