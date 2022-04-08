using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Present_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> houses = Console.ReadLine()
                .Split("@")
                .Select(int.Parse)
                .ToList();



            string command = Console.ReadLine();

            while (true)
            {
                if (command == "Merry Xmas!")
                {
                    break;
                }

                string[] currunt = command.Split().ToArray();

                int numberToJump = int.Parse(currunt[1]);

                

                for (int i = 0; i < houses.Count; i++)
                {
                    if (numberToJump > houses.Count - 1)
                    {
                        numberToJump = numberToJump - houses.Count;
                    }

                    houses[i + numberToJump] -= numberToJump;
                    int index = i + numberToJump;
                    break;
                }

                command = Console.ReadLine();
            }

        }
    }
}
