using System;
using System.Linq;

namespace _04._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split();

            Console.WriteLine(string.Join(' ', input.Reverse()));
                
        }
    }
}
