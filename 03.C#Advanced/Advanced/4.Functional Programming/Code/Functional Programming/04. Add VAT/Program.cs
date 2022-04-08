using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(", ")
                .Select(double.Parse)
                .Select(x => x * 1.20)
                .Select(x => x.ToString("f2"))
                .ToArray();

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
