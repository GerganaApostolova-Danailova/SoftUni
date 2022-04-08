using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenderAge
{
    class Program
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            string Gender = Console.ReadLine();

            if (Gender== "f")
            {
                if (age >= 16)
                {
                    Console.WriteLine("Ms.");
                }
                else
                {
                    Console.WriteLine("Miss");
                }
            }
            if (Gender == "m")
            {
                if (age >= 16)
                {
                    Console.WriteLine("Mr.");
                }
                else
                {
                    Console.WriteLine("Master");
                }
            }
        }
    }
}
