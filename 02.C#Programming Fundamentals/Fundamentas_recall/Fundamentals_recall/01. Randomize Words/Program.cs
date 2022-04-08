using System;

namespace _01._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split();

            Random rdm = new Random();

            for (int i = 0; i < input.Length; i++)
            {
                int currentIndex = rdm.Next(i, input.Length - 1);

                Console.WriteLine(input[currentIndex]);
            }
        }
    }
}
