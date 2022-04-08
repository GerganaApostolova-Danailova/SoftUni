using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;


namespace _01._Animal_Sanctuary
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int weight = 0;

            for (int i = 0; i < num; i++)
            {
                string command = Console.ReadLine();

                if (command.Contains("n:") && command.Contains(";t:") && command.Contains(";c--"))
                {
                    foreach (var digit in command)
                    {
                        if (char.IsDigit(digit))
                        {
                            weight += digit - 48;
                        }
                    }

                    string[] stringSeparators = new string[] { "n:", ";t:", ";c--" };

                    List<string> input = command
                        .Split(stringSeparators, StringSplitOptions.None)
                        .ToList();


                    string name = input[1];
                    string animal = input[2];
                    string country = input[3];

                    string pattern = @"[A-Za-z ]";

                    MatchCollection nameMatch = Regex.Matches(name, pattern);
                    MatchCollection animalMatch = Regex.Matches(animal, pattern);
                    MatchCollection countryMatch = Regex.Matches(country, pattern);

                    string codeName = " ";
                    string codeAnimal = " ";
                    string codeCountry = " ";

                    foreach (Match item in nameMatch)
                    {
                        codeName += item.Value;
                    }
                    foreach (Match item in animalMatch)
                    {
                        codeAnimal += item.Value;
                    }
                    foreach (Match item in countryMatch)
                    {
                        codeCountry += item.Value;
                    }

                    Console.WriteLine($"{codeName.TrimStart()} is a {codeAnimal.TrimStart()} from {codeCountry.TrimStart()}");

                }
            }
            Console.WriteLine($"Total weight of animals: {weight}KG");
        }
    }
}
