using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation22
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            int counter = 1;
            double srocenka = 0;
            int bedCounter = 0;


            while (counter <= 12)
            {
                double ocenka = double.Parse(Console.ReadLine());


                if (ocenka >= 4)
                {
                    srocenka += ocenka;
                    if (counter == 12)
                    {
                        double average = srocenka / 12;
                        Console.WriteLine($"{name} graduated. Average grade: {average:f2}");
                        break;
                    }
                    counter++;
                }
                else
                {
                    bedCounter++;
                    if (bedCounter > 1)
                    {


                        Console.WriteLine($"{name} has been excluded at {counter} grade");
                        break;
                    }
                }


            }
            
          
        }
    }
}
