using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            PrintMiddleCharacters(input);
        }

        static void PrintMiddleCharacters(string input)
        {
            if (input.Length % 2 != 0)
            {
                int index = input.Length / 2;
                Console.WriteLine(input[index]);
            }
            else
            {
                int index = input.Length / 2;
                Console.WriteLine($"{input[index-1]}{input[index]}");
            }      
        }
    }
}
