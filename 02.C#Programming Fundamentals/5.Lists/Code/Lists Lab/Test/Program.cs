using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
              .Split()
              .ToList();
              

            Console.WriteLine(string.Join(" ",input));
        }
    }
}
