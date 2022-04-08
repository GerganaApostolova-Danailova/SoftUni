using System;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            int count = 0;
            int counter = GetVowel(command, count);
            Console.WriteLine(counter);
        }

        static int GetVowel(string command, int count)
        {
            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == 'a' || command[i] == 'e'
                    || command[i] == 'i' || command[i] == 'o'
                    || command[i] == 'u' || command[i] == 'y'||
                    command[i] == 'A' || command[i] == 'E'
                    || command[i] == 'I' || command[i] == 'O'
                    || command[i] == 'U' || command[i] == 'Y')
                {
                    count++;
                }
                else
                {
                    continue;
                }
            }

            return count;
        }
    }
}
