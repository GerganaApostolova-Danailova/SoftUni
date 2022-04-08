using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;


namespace _2._Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([^0-9]+)([0-9]+)";

            string input = Console.ReadLine().ToUpper();

            List<char> uniqueSymbols = new List<char>();

            StringBuilder sb = new StringBuilder();

            MatchCollection match = Regex.Matches(input, pattern);

            foreach (Match word in match)
            {
                string beforeNum = word.Groups[1].Value;
                int repiteNum = int.Parse(word.Groups[2].Value);


                for (int i = 0; i < repiteNum; i++)
                {
                    sb.Append(beforeNum);
                }

                if (repiteNum > 0)
                {
                    for (int j = 0; j < beforeNum.Length; j++)
                    {
                        if (!uniqueSymbols.Contains(beforeNum[j]))
                        {
                            uniqueSymbols.Add(beforeNum[j]);
                        }
                    }
                }
            }



            Console.WriteLine($"Unique symbols used: {uniqueSymbols.Count}");
            Console.WriteLine(sb.ToString());


        }
    }
}
