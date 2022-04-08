using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _03._The_Isle_of_Man_TT_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([#$%*&])(?<name>[A-Za-z]+)\1=(?<lenght>[0-9]+)!!(?<code>.+)$";

            while (true)
            {

                bool something = true;
                string code = Console.ReadLine();
                MatchCollection codeMatch = Regex.Matches(code, pattern);

                foreach (Match codes in codeMatch)
                {
                    string name = codes.Groups["name"].Value;
                    int lenght = int.Parse(codes.Groups["lenght"].Value);
                    string messige = codes.Groups["code"].Value;

                    string newMessege = string.Empty;

                    if (messige.Length == lenght)
                    {
                        foreach (var word in messige)
                        {
                            newMessege += (char)(word + lenght);
                        }
                        Console.WriteLine($"Coordinates found! {name} -> {newMessege}");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                        something = false;
                        break;
                    }
                }
                if (something)
                {
                    Console.WriteLine("Nothing found!");
                }
            }
        }
    }
}
