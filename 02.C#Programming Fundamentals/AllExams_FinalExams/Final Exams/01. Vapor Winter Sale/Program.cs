using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _01._Vapor_Winter_Sale
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ");

            Dictionary<string, double> gameAndPrice = new Dictionary<string, double>();
            Dictionary<string, Dictionary<string, double>> gameDLCAndPrice = new Dictionary<string, Dictionary<string, double>>();


            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Contains("-"))
                {
                    string [] gamePrice = input[i]
                        .Split("-");

                    string game = gamePrice[0];
                    double price = double.Parse(gamePrice[1]);
                    bool isValid = false;

                    foreach (var ch in game)
                    {
                        if (char.IsLetterOrDigit(ch) || ch == ' ')
                        {
                            isValid = true;
                        }
                        else
                        {
                            isValid = false;
                            break;
                        }
                    }
                    if (isValid && !gameAndPrice.ContainsKey(game))
                    {
                        gameAndPrice.Add(game, price);
                    }

                }
                else if (input[i].Contains(":"))
                {
                    string[] gameDLC = input[i]
                        .Split(":");

                    string game = gameDLC[0];
                    string DLC = gameDLC[1];

                    if (gameAndPrice.ContainsKey(game))
                    {
                        double priceWithDLC = gameAndPrice[game] * 1.2;
                        gameDLCAndPrice.Add(game, new Dictionary<string, double>());
                        gameDLCAndPrice[game].Add(DLC, priceWithDLC);
                        gameAndPrice.Remove(game);
                    }

                }
            }

            foreach (var kvp in gameDLCAndPrice)
            {
                foreach (var kvp2 in kvp.Value.OrderBy(x=>x.Value))
                {
                    Console.WriteLine($"{kvp.Key} - {kvp2.Key} - {(kvp2.Value*0.5):f2}");
                }
               
            }

            foreach (var kvp3 in gameAndPrice.OrderByDescending(x=>x.Value))
            {
                Console.WriteLine($"{kvp3.Key} - {(kvp3.Value*0.8):f2}");
            }
        }
    }
}
