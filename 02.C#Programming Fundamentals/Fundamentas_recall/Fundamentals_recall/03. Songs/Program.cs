using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split("_");

                string typeList = command[0];
                string name = command[1];
                string time = command[2];

                Song song = new Song(typeList, name, time);

                songs.Add(song);
            }

            string finalCommand = Console.ReadLine();

            if (finalCommand == "all")
            {
                foreach (var song in songs)
                {
                    Console.WriteLine(song);
                }
            }
            else
            {
                var selectedSongs = songs
                    .Where(x => x.TypeList == finalCommand);

                foreach (var song in selectedSongs)
                {
                    Console.WriteLine(song);
                }
            }
        }

        public class Song
        {
            public string TypeList { get; set; }

            public string Name { get; set; }

            public string Time { get; set; }


            public Song(string typeList, string name, string time)
            {
                this.TypeList = typeList;
                this.Name = name;
                this.Time = time;
            }

            public override string ToString()
            {
                return this.Name;
            }
        }
    }
}
