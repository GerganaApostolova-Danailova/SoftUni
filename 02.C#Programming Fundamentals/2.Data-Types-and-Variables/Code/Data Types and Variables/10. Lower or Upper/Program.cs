using System;
using System.Linq;


namespace _10._Lower_or_Upper
{
    class Program
    {
        static void Main(string[] args)
        {
            char letter = char.Parse(Console.ReadLine());

            bool result;          
            result = Char.IsUpper(letter);

            if (result)
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
            
        }
    }
}
