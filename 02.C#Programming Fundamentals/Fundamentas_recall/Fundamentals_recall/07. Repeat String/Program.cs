using System;

namespace _07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int numToRepeat = int.Parse(Console.ReadLine());

            GetRepeatString(input, numToRepeat);
            Console.WriteLine(GetRepeatString(input, numToRepeat));
        }

        static string GetRepeatString(string input, int numToRepeat)
        {
            string command = string.Empty;

            for (int i = 0; i < numToRepeat; i++)
            {
                command += input;
            }

            return command;
        }
    }
}
