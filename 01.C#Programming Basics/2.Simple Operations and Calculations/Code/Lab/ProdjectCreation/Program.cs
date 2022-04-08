using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdjectCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int projectCount = int.Parse(Console.ReadLine());

            int hours = projectCount * 3;
            Console.WriteLine($"The architect {name} will need {hours} hours to complete {projectCount} project/s.");
        }
    }
}
