using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Bread_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                .Split("|")
                .ToArray();

            int energy = 100;
            int coins = 100;

            bool outOfBacker = false;

            for (int i = 0; i < arr.Length; i++)
            {

                string[] currentRoom = arr[i].Split("-").ToArray();

                if (currentRoom[0] == "rest")
                {
                    int number = int.Parse(currentRoom[1]);

                    if (energy >= 100)
                    {
                        Console.WriteLine($"You gained {0} energy.");
                        Console.WriteLine($"Current energy: {energy}.");
                    }
                    else
                    {
                        if (energy + number >= 100)
                        {
                            number = 100 - energy;
                            energy = 100;
                        }
                        else
                        {
                            energy += number;

                        }

                        Console.WriteLine($"You gained {number} energy.");
                        Console.WriteLine($"Current energy: {energy}.");
                    }
                }
                else if (currentRoom[0] == "order")
                {
                    int number = int.Parse(currentRoom[1]);
                    
                    if (energy >= 30)
                    {
                    energy -= 30;
                    coins += number;
                    Console.WriteLine($"You earned {number} coins.");

                    }
                    else
                    {
                        energy += 50;
                      Console.WriteLine("You had to rest!");
                    }

                }
                else if (currentRoom[0] != "order" && currentRoom[0] != "rest")
                {
                    string ingredient = currentRoom[0];
                    int number = int.Parse(currentRoom[1]);

                    coins -= number;

                    if (coins <= 0)
                    {
                        Console.WriteLine($"Closed! Cannot afford {ingredient}.");
                        outOfBacker = false;
                        return;
                    }
                    else if (coins > 0)
                    {
                        Console.WriteLine($"You bought {ingredient}.");
                    }

                }

                outOfBacker = true;
            }
            if (outOfBacker)
            {
                Console.WriteLine("Day completed!");
                Console.WriteLine($"Coins: {coins}");
                Console.WriteLine($"Energy: {energy}");
            }
        }
    }
}
