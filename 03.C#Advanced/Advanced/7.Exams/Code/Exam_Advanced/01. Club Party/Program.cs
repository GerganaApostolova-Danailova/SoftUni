using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Club_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());

            string[] reservationAndRooms = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Stack<string> reserve = new Stack<string>(reservationAndRooms);

            Dictionary<string, List<int>> roomPeople = new Dictionary<string, List<int>>();

            while (reserve.Any())
            {
                string currentRoom = reserve.Pop();

                int currentPeople;

                if (!int.TryParse(currentRoom, out currentPeople))
                {
                    roomPeople.Add(currentRoom, new List<int>());
                }
                else
                {
                    if (roomPeople.Any())
                    {
                        foreach (var room in roomPeople)
                        {
                            if (room.Value.Sum() + currentPeople <= capacity)
                            {
                                roomPeople[room.Key].Add(currentPeople);

                                if (room.Value.Sum() == capacity)
                                {
                                    Console.Write($"{room.Key} -> ");
                                    Console.Write(string.Join(", ", room.Value));
                                    Console.WriteLine();
                                    roomPeople.Remove(room.Key);
                                }
                            }
                            else
                            {
                                Console.Write($"{room.Key} -> ");
                                Console.Write(string.Join(", ", room.Value));
                                Console.WriteLine();
                                roomPeople.Remove(room.Key);
                                reserve.Push(currentPeople.ToString());
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
}
