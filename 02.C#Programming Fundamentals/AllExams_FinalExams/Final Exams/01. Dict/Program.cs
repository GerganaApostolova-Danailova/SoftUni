using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _01._Dict
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (true)
            {
                string command2 = Console.ReadLine();

                if (command2 == "Done")
                {
                    break;
                }

                string[] command = command2
                    .Split();

                string manipulation = command[0];

                if (manipulation == "Change")
                {
                    string char1 = command[1];
                    string replaced = command[2];

                    if (input.Contains(char1))
                    {
                        input = input.Replace(char1, replaced);
                        Console.WriteLine(input);
                    }
                }
                else if (manipulation == "Includes")
                {
                    string string1 = command[1];

                    if (input.Contains(string1))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (manipulation == "End")
                {
                    string string1 = command[1];

                    if (input.Contains(string1))
                    {
                        int index = input.LastIndexOf(string1);
                        int lenghtOfString = string1.Length;

                        if (index + lenghtOfString == input.Length)
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (manipulation == "Uppercase")
                {
                    input = input.ToUpper();
                    Console.WriteLine(input);
                }
                else if (manipulation == "FindIndex")
                {
                    string char1 = command[1];

                    if (input.Contains(char1))
                    {
                        int index = input.IndexOf(char1);

                        Console.WriteLine($"{index}");
                    }
                }
                else if (manipulation == "Cut")
                {
                    int startIndex = int.Parse(command[1]);
                    int lenght = int.Parse(command[2]);

                    string output = string.Empty;

                    if (input.Length >= lenght)
                    {
                        output = input.Substring(startIndex, lenght);
                    Console.WriteLine(output);
                    }

                }

            }
        }
    }
}
