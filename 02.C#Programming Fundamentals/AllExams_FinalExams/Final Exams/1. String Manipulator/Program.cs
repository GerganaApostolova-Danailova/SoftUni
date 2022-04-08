using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _1._String_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            string result = string.Empty;

            while (input != "End")
            {
                string[] command = input
                    .Split();


                string manipulation = command[0];

                if (manipulation == "Add")
                {
                    string concat = command[1];

                    result += concat;
                }
                else if (manipulation == "Print")
                {
                    Console.WriteLine(result);
                }
                else if (manipulation == "Upgrade")
                {
                    char ch = char.Parse(command[1]);

                    char replace =(char)(ch + 1);

                    if (result.Contains(ch))
                    {
                        result = result.Replace(ch, replace);
                            
                    }
                }
                else if (manipulation == "Index")
                {
                    char ch = char.Parse(command[1]);

                    if (result.Contains(ch))
                    {
                        for (int i = 0; i < result.Length; i++)
                        {
                            if (result[i] == ch) 
                            {
                                Console.Write($"{i} ");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("None");
                    }
                }
                else if (manipulation == "Remove")
                {
                    string remuveString = command[1];
                    int lenghtOfString = remuveString.Length;

                    if (result.Contains(remuveString))
                    {
                        int index = result.IndexOf(remuveString);

                        while (index != -1)
                        {
                            result = result.Remove(index, lenghtOfString);
                            index = result.IndexOf(remuveString);
                        }
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}
