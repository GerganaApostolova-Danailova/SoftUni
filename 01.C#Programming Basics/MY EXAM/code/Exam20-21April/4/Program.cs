using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            int FirstPlayerEggs = int.Parse(Console.ReadLine());
            int SecondPlayerEggs = int.Parse(Console.ReadLine());


            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End of battle")
            {
                if(command == "one")
                {
                    SecondPlayerEggs -= 1;
                }
                else if (command == "two")
                {
                    FirstPlayerEggs -= 1;
                }
                if (FirstPlayerEggs == 0 )
                {
                    Console.WriteLine($"Player one is out of eggs. Player two has {SecondPlayerEggs} eggs left.");
                    break;
                }
                if (SecondPlayerEggs == 0)
                {
                    Console.WriteLine($"Player two is out of eggs. Player one has {FirstPlayerEggs} eggs left.");
                    break;
                }
            }
            if (command == "End of battle")
            {
                Console.WriteLine($"Player one has {FirstPlayerEggs} eggs left.");
                Console.WriteLine($"Player two has {SecondPlayerEggs} eggs left.");
            }

        }
    }
}
