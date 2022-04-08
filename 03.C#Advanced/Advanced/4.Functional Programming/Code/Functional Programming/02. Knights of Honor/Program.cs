using System;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = items => 
            {
                foreach (var names in items)
                {
                    Console.WriteLine($"Sir {names}");
                }
            };

            string[] name = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries);

            print(name);
        }
    }
}
