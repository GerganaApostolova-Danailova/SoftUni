using System;

namespace _08._Town_Info
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            decimal people = decimal.Parse(Console.ReadLine());
            int kilometers = int.Parse(Console.ReadLine());

            Console.WriteLine($"Town {city} has population of {people} and area {kilometers} square km.");
        }
    }
}
