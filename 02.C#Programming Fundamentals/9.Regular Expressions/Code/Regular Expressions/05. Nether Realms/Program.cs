using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _05._Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string healtPattern = @"[^0-9+\-*\/.]";
            Regex healtRegex = new Regex(healtPattern);

            string digitPattern = @"-?\d+\.?\d*";
            Regex digitRegex = new Regex(digitPattern);

            string operatorPattern = @"[*\/]";
            Regex operatorRegex = new Regex(operatorPattern);


            string[] demonNames = Regex
                .Split(Console.ReadLine(), @"\s*,\s*")
                .OrderBy(x => x)
                .ToArray();

            for (int i = 0; i < demonNames.Length; i++)
            {
                string currentDemon = demonNames[i];

                int currentHealt = 0;

                MatchCollection healtSymbols = healtRegex.Matches(currentDemon);

                foreach (Match healt in healtSymbols)
                {
                    currentHealt += char.Parse(healt.Value);
                }

                double currentDeamon = 0;

                MatchCollection deamonDemije = digitRegex.Matches(currentDemon);

                foreach (Match deamon in deamonDemije)
                {
                    currentDeamon += double.Parse(deamon.Value);
                }

                MatchCollection operatorMAtch = operatorRegex.Matches(currentDemon);

                foreach (Match operatorr in operatorMAtch)
                {

                    string @operator = operatorr.Value;

                    if (@operator == "*")
                    {
                        currentDeamon *= 2;
                    }
                    else
                    {
                        currentDeamon /= 2;
                    }

                }

                Console.WriteLine($"{currentDemon} - {currentHealt} health, {currentDeamon:f2} damage");
            }

        }
    }
}
