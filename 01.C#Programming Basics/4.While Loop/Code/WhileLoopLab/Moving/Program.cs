using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int w = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());

            int cubicMeters = w * l * h;
            string command = Console.ReadLine();
            int boxes = 0;

            while (command != "Done")
            {
                boxes += int.Parse(command);

                if (cubicMeters <= boxes)
                {
                    Console.WriteLine($"No more free space!You need {boxes - cubicMeters} Cubic meters more.");
                }

                command = Console.ReadLine();
            }
            if (command == "Done")
            {
                Console.WriteLine($"{cubicMeters - boxes} Cubic meters left.");
            }
        }
    }
}
