using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts
{
    class Program
    {


        static void Main(string[] args)
        {
            string PlayerName = Console.ReadLine();

            string command = string.Empty;
            int TotalScore = 301;
            int winShoot = 0;
            int looseShoets = 0;


            while ((command = Console.ReadLine()) != "Retire" || TotalScore == 0)
            {
                int MomentScore = int.Parse(Console.ReadLine());

                if (command == "Triple")
                {

                    if (TotalScore < (MomentScore * 3))
                    {
                        looseShoets++;
                    }
                    else
                    {
                        TotalScore -= (MomentScore * 3);
                        winShoot++;
                    }
                }

                else if (command == "Double")
                {

                    if (TotalScore < (MomentScore * 2))
                    {
                        looseShoets++;
                    }
                    else
                    {
                        TotalScore -= (MomentScore * 2);
                        winShoot++;
                    }

                }
                else if (command == "Single")
                {
                    if (TotalScore < (MomentScore * 1))
                    {
                        looseShoets++;
                    }
                    else
                    {
                        TotalScore -= (MomentScore * 1);
                        winShoot++;
                    }
                }
                

                if (TotalScore == 0)
                {
                    break;
                }               
            }

            if (command == "Retire")
            {
                Console.WriteLine($"{PlayerName} retired after {looseShoets} unsuccessful shots.");

            }
            else if (TotalScore == 0)
            {
                Console.WriteLine($"{PlayerName} won the leg with {winShoot} shots.");

            }

        }
    }
}
