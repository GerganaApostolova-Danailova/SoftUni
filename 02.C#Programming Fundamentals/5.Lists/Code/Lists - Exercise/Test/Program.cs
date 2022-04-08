using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> player1 = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();

            player1.RemoveRange(0, 1);

            Console.WriteLine(string.Join(" ",player1));
        }
    }
}
