using System;
using System.Linq;
using System.Collections.Generic;


namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split()
                .ToList();

            Predicate<string> isLong = name => name.Length <= length;

            var result = names.FindAll(x=> isLong(x)).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
