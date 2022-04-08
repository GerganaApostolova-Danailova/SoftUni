using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<name>.+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)";

            List<string> furntures = new List<string>();
            decimal sum = 0;

            string input = Console.ReadLine();

            while (input != "Purchase")
            {

                Match match = Regex.Match(input,pattern);


                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    decimal price = decimal.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);

                    furntures.Add(name);

                    sum += price * quantity;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");

            foreach (var furniture in furntures)
            {
                Console.WriteLine(furniture);
            }

            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}
