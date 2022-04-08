using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _04._Star_Enigm
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();


            for (int i = 0; i < num; i++)
            {
                string input = Console.ReadLine();

                string pattern = @"[starSTAR]";

                MatchCollection matches = Regex.Matches(input, pattern);

                int count = 0;

                string message = string.Empty;

                foreach (Match match in matches)
                {
                    if (match.Success)
                    {
                        count++;
                    }
                }
                foreach (var ch in input)
                {
                    message += (char)(ch - count);
                }

                string pattern2 = @"^[^\@\-!:>]*@(?<planet>[A-za-z]+)[^\@\-!:>]*:(?<population>\d+)[^\@\-!:>]*!(?<attack>[A|D])![^\@\-!:>]*->(?<solderCount>\d+)[^\@\-!:>]*$";

                Match matches2 = Regex.Match(message, pattern2);
                
                if (matches2.Success)
                {
                    string planet = matches2.Groups["planet"].Value;
                    string attack = matches2.Groups["attack"].Value;

                    if (attack == "A")
                    {
                        attackedPlanets.Add(planet);

                    }
                    else
                    {
                        destroyedPlanets.Add(planet);
                    }

                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

            if (attackedPlanets.Count > 0)
            {
                foreach (var planet in attackedPlanets.OrderBy(x => x))
                {
                    Console.WriteLine($"-> {planet}");
                }
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            if (destroyedPlanets.Count() > 0)
            {
                foreach (var planet in destroyedPlanets.OrderBy(x => x))
                {
                    Console.WriteLine($"-> {planet}");
                }

            }
        }
    }
}
