using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char inputOne = char.Parse(Console.ReadLine());
            char inputTwo = char.Parse(Console.ReadLine());

            PrintTheCharsBetweenTwoChars(inputOne, inputTwo);
        }

        private static void PrintTheCharsBetweenTwoChars(char firstCharacter, char secondCharacter)
        {
            int startCharacter = Math.Min(firstCharacter, secondCharacter);
            int endCharacter = Math.Max(firstCharacter, secondCharacter);

            for (int i = startCharacter+1; i < endCharacter; i++)
            {
                Console.Write((char)i + " ");
            }

            Console.WriteLine();
        }
    }
}
