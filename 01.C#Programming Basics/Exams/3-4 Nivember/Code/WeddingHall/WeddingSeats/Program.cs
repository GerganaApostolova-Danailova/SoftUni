using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingSeats
{
    class Program
    {
        static void Main(string[] args)
        {
            int mens = int.Parse(Console.ReadLine());
            int womens = int.Parse(Console.ReadLine());
            int maxTabels = int.Parse(Console.ReadLine());

            int counter = 0;

            for (int i = 1; i <= mens; i++)
            {
                for (int j = 1; j <= womens; j++)
                {
                    if(counter < maxTabels)
                    {
                        Console.Write($"({i} <-> {j}) ");
                    }
                    else
                    {
                        break;
                    }
                    counter++;
                }
            }
        }
    }
}
