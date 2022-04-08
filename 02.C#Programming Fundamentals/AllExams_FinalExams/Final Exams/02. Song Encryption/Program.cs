using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _02._Song_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string namePattern = @"^(?<name>[A-Z]{1}[a-z' ]+)$";

            string songPattern = @"^(?<song>[A-Z ]+)$";

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] nameAndSong = command
                    .Split(":");

                string name = nameAndSong[0];
                string song = nameAndSong[1];

                int key = name.Length;

                string output = string.Empty;

                Match nameMatches = Regex.Match(name, namePattern);
                Match songMatches = Regex.Match(song, songPattern);


                if (nameMatches.Success && songMatches.Success)
                {
                    string incoruptedName = nameMatches.Value;
                    string incoruptedSong = songMatches.Value;

                    Console.Write($"Successful encryption: ");

                    foreach (var ch in incoruptedName)
                    {
                        if (ch != ' ' && ch != '\'' && char.IsLower(ch) && ch + key <= 122)
                        {
                            output += (char)(ch + key);
                        }
                        else if (ch != ' ' && ch != '\'' && char.IsLower(ch) && ch + key > 122)
                        {
                            int newKey = (ch + key) - 122;
                            output += (char)(96 + newKey);
                        }
                        else if (ch != ' ' && ch != '\'' && char.IsUpper(ch) && ch + key <= 90)
                        {
                            output += (char)(ch + key);
                        }
                        else if (ch != ' ' && ch != '\'' && char.IsUpper(ch) && ch + key > 90)
                        {
                            int newKey = (ch + key) - 90;
                            output += (char)(64 + newKey);
                        }
                        else if (ch == ' ')
                        {
                            output += ' ';
                        }
                        else if (ch == '\'')
                        {
                            output += '\'';
                        }
                    }
                    output += "@";

                    foreach (var ch in incoruptedSong)
                    {
                        if (ch != ' ' && ch + key <= 90)
                        {
                            output += (char)(ch + key);
                        }
                        else if (ch != ' ' && ch + key > 90)
                        {
                            int newKey = (ch + key) - 90;
                            output += (char)(64 + newKey);
                        }
                        else if (ch == ' ')
                        {
                            output += ' ';
                        }
                    }

                    Console.WriteLine(output);
                }
                else
                {
                    Console.WriteLine($"Invalid input!");
                }

            }



        }
    }
}
