using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _02.String
{
    class Program
    {
        static void Main(string[] args)
        {

            string pattern = @"([*|@])(?<tag>[A-Z]{1}[a-z]{2,})\1:\s(\[(?<one>[A-Za-z]{1})\]\|)(\[(?<two>[A-Za-z]{1})\]\|)(\[(?<tree>[A-Za-z]{1})\]\|)$";
            //string pattern = @"([*|@])(?<tag>[[A-Z][a-z]{3,})\1(:\s){1}(\[(?<one>[A-Za-z])\]\|)(\[(?<two>[A-Za-z])\]\|)(\[(?<tree>[A-Za-z])\]\|)$";

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string messeges = Console.ReadLine();

                Match match = Regex.Match(messeges, pattern);

                if (match.Success)
                {
                    var tag = match.Groups["tag"].Value;
                    var one = char.Parse(match.Groups["one"].Value);
                    var two = char.Parse(match.Groups["two"].Value);
                    var tree = char.Parse(match.Groups["tree"].Value);

                    Console.WriteLine($"{tag}: {(int)one} {(int)two} {(int)tree}");

                }
                else
                {
                    Console.WriteLine($"Valid message not found!");
                }
            }
        }
    }
}
