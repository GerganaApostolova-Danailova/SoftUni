using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _4._Santa_s_Secret_Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());

            string pattern = @"@(?<name>[A-Za-z]+)([^@\-!:>]*)!(?<goodOrBad>[G|N])!";

            while (true)
            {
                string encryptedCode = Console.ReadLine();

                if (encryptedCode == "end")
                {
                    break;
                }


                string code = string.Empty;

                foreach (char ch in encryptedCode)
                {
                    code += (char)(ch - key);
                }

                MatchCollection match = Regex.Matches(code, pattern);

                foreach (Match item in match)
                {
                    string badOrGood = item.Groups["goodOrBad"].Value;

                    if (badOrGood == "G")
                    {
                        string name = item.Groups["name"].Value;

                        Console.WriteLine(name);
                    }

                }
            }
        }
    }
}
