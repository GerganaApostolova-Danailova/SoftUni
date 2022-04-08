using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _01._Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = new string[] { "Excellent product.", "Such a great product.",
                "I always use that product.", "Best product of its category.",
                "Exceptional product.", "I can’t live without this product." };

            string[] events = new string[] { "Now I feel good.", "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.", "I feel great!" };

            string[] authors = new string[] { "Diana", "Petya", "Stella", "Elena",
                "Katya", "Iva", "Annie", "Eva" };

            string[] cities = new string[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };


            int num = int.Parse(Console.ReadLine());

            var random = new Random();

            for (int i = 0; i < num; i++)
            {
                int phrasesIndex = random.Next(0, phrases.Length);
                int eventsIndex = random.Next(0, events.Length);
                int authorsIndex = random.Next(0, authors.Length);
                int citiesIndex = random.Next(0, cities.Length);

                string messige = $"{phrases[phrasesIndex]} {events[eventsIndex]} {authors[authorsIndex]} - {cities[citiesIndex]}";

                Console.WriteLine(messige);
            }
        }
    }
}
