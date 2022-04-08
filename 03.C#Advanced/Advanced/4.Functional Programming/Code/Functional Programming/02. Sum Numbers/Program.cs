using System;
using System;
using System.Linq;
using System.Collections.Concurrent;

namespace _02._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Where(word=>char.IsUpper(word[0]));

            foreach (var item in words)
            {
                Console.WriteLine(item);
            }
        }
    }
}
