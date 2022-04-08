using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace _01._Extract_Person_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            string name = string.Empty;
            int age = 0;

            for (int i = 0; i < num; i++)
            {
                string enter = Console.ReadLine();

                string[] input = enter
                    .Split();


                for (int j = 0; j < input.Length; j++)
                {
                    string currentINput = input[j];

                    if (currentINput[0] == '@' && currentINput[currentINput.Length - 1] == '|')
                    {
                        name = currentINput.Substring(1, currentINput.Length - 2);
                    }
                    if (currentINput[0] == '#' && currentINput[currentINput.Length - 1] == '*')
                    {
                        age = int.Parse(currentINput.Substring(1, currentINput.Length - 2));
                    }
                    else
                    {
                        continue;
                    }
                }

                Console.WriteLine(name + $" is {age} years old.");
            }
        }
    }
}
