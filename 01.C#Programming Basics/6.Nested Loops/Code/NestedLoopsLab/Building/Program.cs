using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberFlore = int.Parse(Console.ReadLine());
            int roomToFlore = int.Parse(Console.ReadLine());

            for (int floor = numberFlore; floor >=1; floor--)
            {
                for (int room = 0; room < roomToFlore; room++)
                {
                    if (floor == numberFlore)
                    {
                        Console.Write($"L{floor}{room} ");
                    }
                    else if (floor % 2 == 0)
                    {
                        Console.Write($"O{floor}{room} ");
                    }
                    else
                    {
                        Console.Write($"A{floor}{room} ");
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
