using System;
using System.Collections.Generic;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = new List<string>();

            while (true)
            {
                string currentGuest = Console.ReadLine();

                if (currentGuest == "PARTY")
                {
                    break;
                }

                if (currentGuest.Length == 8)
                {
                    guests.Add(currentGuest);
                }
            }

            while (true)
            {
                string currentGuest = Console.ReadLine();

                if (currentGuest == "END")
                {
                    break;
                }
                if (guests.Contains(currentGuest))
                {
                    guests.Remove(currentGuest);

                }
            }

            Console.WriteLine(guests.Count);

            HashSet<string> numberFirs = new HashSet<string>();

            for (int i = 0; i < guests.Count; i++)
            {
                char currentChar = guests[i][0];

                if (char.IsDigit(currentChar))
                {
                    numberFirs.Add(guests[i]);
                    guests.Remove(guests[i]);
                }
            }

            if (numberFirs.Count > 0)
            {
                foreach (var item in numberFirs)
                {
                    Console.WriteLine(item);
                }

            }
            if (guests.Count > 0)
            {
                foreach (var item in guests)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
