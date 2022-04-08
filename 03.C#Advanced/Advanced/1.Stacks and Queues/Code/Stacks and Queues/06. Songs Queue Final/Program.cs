using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _06._Songs_Queue_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ");

            Queue<string> singsPlaylist = new Queue<string>(input);

            while (singsPlaylist.Count > 0)
            {
                string command = Console.ReadLine();

                if (command == "Play")
                {
                    singsPlaylist.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    string[] currentSong = command
                        .Split("Add ");

                    string song = currentSong[1];

                    if (singsPlaylist.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        singsPlaylist.Enqueue(song);
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", singsPlaylist));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
