using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2._Dungeonest_Dark
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                .Split("|");

            int health = 100;
            int coins = 0;

            bool outOfRoom = false;

            for (int i = 1; i <= arr.Length; i++)
            {

                List<string> currentRoom = arr[i-1].Split().ToList();

                if (currentRoom[0] == "potion")
                {
                    int number = int.Parse(currentRoom[1]);

                    if (health >= 100)
                    {
                        Console.WriteLine($"You healed for {0} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                    else
                    {
                        if (health + number > 100)
                        {
                            number = 100 - health;
                            health = 100;
                        }
                        else
                        {
                        health += number;

                        }

                        Console.WriteLine($"You healed for {number} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                }
                else if (currentRoom[0] == "chest")
                {
                    int number = int.Parse(currentRoom[1]);

                    coins += number;

                    Console.WriteLine($"You found {number} coins.");
                }
                else if (currentRoom[0] != "chest" && currentRoom[0] != "potion")
                {
                    string monster = currentRoom[0];
                    int number = int.Parse(currentRoom[1]);

                    health -= number;

                    if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {monster}.");
                        Console.WriteLine($"Best room: {i}");
                        outOfRoom = false;
                        return;
                    }
                    else if (health > 0)
                    {

                    Console.WriteLine($"You slayed {monster}.");
                    }

                }
                
                currentRoom.Clear();
                outOfRoom = true;
            }
            if (outOfRoom)
            {
            Console.WriteLine("You've made it!");
            Console.WriteLine($"Coins: {coins}");
            Console.WriteLine($"Health: {health}");

            }

        }
    }
}
