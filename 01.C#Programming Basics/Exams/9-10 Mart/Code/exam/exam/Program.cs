﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberWars
{
    class Program
    {
        static void Main(string[] args)
        {
            string FurstPlayerNAme = Console.ReadLine();
            string SecondPlayerNAme = Console.ReadLine();

            string command = Console.ReadLine();
          
           
            int countPointsFirstPlayer = 0;
            int countPointstSecondPlayer = 0;
         

            while (command != "End of game")
            {
                int CardFirstPlayer = int.Parse(command);
                int CardSecondPlayer = int.Parse(Console.ReadLine());

               
                
                int PointsFirstPlayer = CardFirstPlayer - CardSecondPlayer;
                int pointsSecondPlayer = CardSecondPlayer - CardFirstPlayer;

                if (CardFirstPlayer > CardSecondPlayer)
                {
                    
                    countPointsFirstPlayer += PointsFirstPlayer;
                    
                    
                }
               

                else if (CardFirstPlayer < CardSecondPlayer)
                {
                    
                    countPointstSecondPlayer += pointsSecondPlayer;
                    
                   
                    
                }
                else if (CardFirstPlayer == CardSecondPlayer)
                {
                    int CardFirstPlayerwar = int.Parse(Console.ReadLine());
                    int CardSecondPlayerwar = int.Parse(Console.ReadLine());
                    int PointFirstPlayerWar = 0;
                    int PointSecondPlayerWar = 0;

                    if (CardFirstPlayerwar > CardSecondPlayerwar)
                    {
                        PointFirstPlayerWar = CardFirstPlayerwar - CardSecondPlayerwar;
                        Console.WriteLine("Number wars!");
                        Console.WriteLine($"{FurstPlayerNAme} is winner with {PointFirstPlayerWar} points");
                        break;
                    }
                    else if (CardFirstPlayerwar < CardSecondPlayerwar)
                    {
                        PointSecondPlayerWar = CardSecondPlayerwar - CardFirstPlayerwar;
                        Console.WriteLine("Number wars!");
                        Console.WriteLine($"{SecondPlayerNAme} is winner with {PointSecondPlayerWar} points");
                        break;
                    }
                }
                command = Console.ReadLine();
            }
            if (command == "End of game")
            {
                Console.WriteLine($"{FurstPlayerNAme} has {countPointsFirstPlayer} points");
                Console.WriteLine($"{SecondPlayerNAme} has {countPointstSecondPlayer} points");

            }

        }
    }
}