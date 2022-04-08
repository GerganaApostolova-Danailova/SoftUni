using System;

namespace _09._Chars_to_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string sum = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                char one = char.Parse(Console.ReadLine());
                sum += one;

            }

            Console.WriteLine(sum);

        }
    }
}
