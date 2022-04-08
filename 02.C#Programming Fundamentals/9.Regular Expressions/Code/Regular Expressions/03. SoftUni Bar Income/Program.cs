using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>\d+)\|[^|$%.]*?(?<price>\d+\.*\d*)\$";
            //2. string pattern = @"%(?<name>[A-Za-z]*)%([^|$%.]*)<(?<product>\w+)>\1\|(?<quantity>[0-9]+)\|\1?(?<price>[0-9]+\.*[0-9]*)\$";
            //3. string pattern = @"^%(?<name>[A-Z][a-z]*)%[^|$%.]*<(?<product>\w +)>[^|$%.]*\|(?<count>[0-9]+)\|[^|$%.]*?(?<price>[0-9]+\.*[0-9]*)\$$";
            string input = Console.ReadLine();


            double totalIncome = 0;

            while (input != "end of shift")
            {
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string currentName = match.Groups["name"].Value;
                    string currentProduct = match.Groups["product"].Value;
                    int currentQuantiy = int.Parse(match.Groups["quantity"].Value);
                    double CurrentPrice = double.Parse(match.Groups["price"].Value);


                    totalIncome += CurrentPrice * currentQuantiy;

                    Console.WriteLine($"{currentName}: {currentProduct} - {(currentQuantiy * CurrentPrice):f2}");

                    input = Console.ReadLine(); ;
                }
            }
            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
