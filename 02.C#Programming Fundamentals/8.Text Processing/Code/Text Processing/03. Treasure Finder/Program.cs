using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string result = string.Empty;



            while (true)
            {

                string command = Console.ReadLine();
                int count = 0;

                if (command == "find")
                {
                    break;
                }

                foreach (char ch in command)
                {
                    int newchar = ch - num[count];

                    result += (char)newchar;

                    count++;

                    if (count == num.Length)
                    {
                        count = 0;
                    }

                }

            int startTresureIndex = result.IndexOf("&");
            int endTresureIndex = result.LastIndexOf("&");

            int startCodeIndex = result.IndexOf("<");
            int endCodeIndex = result.IndexOf(">");

            string tresure = result.Substring(startTresureIndex +1, endTresureIndex - startTresureIndex -1);
            string code = result.Substring(startCodeIndex+1, endCodeIndex - startCodeIndex-1);

                

            Console.WriteLine($"Found {tresure} at {code}");
                result = string.Empty;
            }

        }
    }
}
