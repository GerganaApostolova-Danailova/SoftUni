using System;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                PrintTrueOrFAlse(command);
                command = Console.ReadLine();
            }
        }

        static void PrintTrueOrFAlse(string command)
        {
            string result1 = " ";
            string result2 = " ";

            for (int i = 0; i < command.Length; i++)
            {
                result1 += command[i];
            }

            for (int i = command.Length - 1; i >= 0; i--)
            {
                result2 += command[i];
            }

            if (result1 == result2)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
