using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _3._Post_Office
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstPartPattern = @"([#$%*&.]+)(?<capitalLetter>[A-Z]+)\1";

            string secondPartPattern = @"(?<word>[0-9]+):(?<lenght>[0-9]{2})(?!(\.))";

            string[] input = Console.ReadLine()
                .Split("|");

            string firstPart = input[0];
            string secondPart = input[1];
            string[] tirthPart = input[2]
                .Split(" ");

            string letters = string.Empty;
            int equalNum = 0;
            int lenght = 0;

            List<string> output = new List<string>();

            Match firstMatch = Regex.Match(firstPart, firstPartPattern);

            if (firstMatch.Success)
            {
                letters = firstMatch.Groups["capitalLetter"].Value;
            }

            MatchCollection secondMatch = Regex.Matches(secondPart, secondPartPattern);

            foreach (Match number in secondMatch)
            {
                equalNum = int.Parse(number.Groups["word"].Value);

                foreach (char ch in letters)
                {
                    if (ch == equalNum)
                    {
                        lenght = int.Parse(number.Groups["lenght"].Value)+1;
                        break;
                    }
                }

                for (int i = 0; i < tirthPart.Length; i++)
                {
                    if (tirthPart[i][0] == equalNum && tirthPart[i].Length == lenght && !output.Contains(tirthPart[i]))
                    {
                        output.Add(tirthPart[i]);
                        break;
                    }
                }


            }
            foreach (char ch in letters)
            {
                for (int i = 0; i < output.Count; i++)
                {
                    if (ch == output[i][0])
                    {
                        Console.WriteLine(output[i]);
                        break;
                    }
                }
            }
        }
    }
}
