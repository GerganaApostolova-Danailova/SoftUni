using System;

namespace _02.EngName_oftheLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();

            int finalNum = num[num.Length-1]-48;
           

            if (finalNum == 0)
            {
                Console.WriteLine("zero");
            }
            else if (finalNum == 1)
            {
                Console.WriteLine("one");
            }
            else if (finalNum == 2)
            {
                Console.WriteLine("two");
            }
            else if (finalNum == 3)
            {
                Console.WriteLine("three");
            }
            else if (finalNum == 4)
            {
                Console.WriteLine("four");
            }
            else if (finalNum == 5)
            {
                Console.WriteLine("five");
            }
            else if (finalNum == 6)
            {
                Console.WriteLine("six");
            }
            else if (finalNum == 7)
            {
                Console.WriteLine("seven");
            }
            else if (finalNum == 8)
            {
                Console.WriteLine("eight");
            }
            else if (finalNum == 9)
            {
                Console.WriteLine("nine");
            }
        }
    }
}
