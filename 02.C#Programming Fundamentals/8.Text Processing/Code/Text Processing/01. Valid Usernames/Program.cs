using System;
using System.Linq;


namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ");

            bool lenght = false;
            bool contains = false;


            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Length >= 3 && input[i].Length <= 16)
                {
                    lenght = true;
                }
                else
                {
                    continue;
                }
                foreach (var word in input[i])
                {
                    bool letterDigit = char.IsLetterOrDigit(word);

                    if (letterDigit || word == '_' || word == '-')
                    {
                        contains = true;
                    }
                    else
                    {
                        contains = false;
                        break;
                    }
                }
                if (lenght && contains)
                {
                    Console.WriteLine($"{input[i]}");
                }
            }

        }
    }
}
