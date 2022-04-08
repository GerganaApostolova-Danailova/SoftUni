using System;

namespace _02._Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char one = char.Parse(Console.ReadLine());
            char two = char.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            int sum = 0;

            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] > one && command[i] < two)
                {
                    sum += command[i];
                }
            }

            Console.WriteLine($"{sum}");
        }
    }
}
