using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalType
{
    class Program
    {
        static void Main(string[] args)
        {
            string AnimalType = Console.ReadLine();

            if (AnimalType=="dog")
            {
                Console.WriteLine("mammal");
            }
            else if (AnimalType == "crocodile")
            {
                Console.WriteLine("reptile");
            }
            else if (AnimalType == "snake")
            {
                Console.WriteLine("reptile");
            }
            else if (AnimalType == "tortoise")
            {
                Console.WriteLine("reptile");
            }
            else 
            {
                Console.WriteLine("unknown");
            }


        }
    }
}
