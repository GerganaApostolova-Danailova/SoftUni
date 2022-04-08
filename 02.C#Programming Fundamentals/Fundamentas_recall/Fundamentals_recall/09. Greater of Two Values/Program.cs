using System;

namespace _09._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            if (command == "int")
            {
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());

                GetMax(num1, num2);
            }
            else if (command == "char")
            {
                char ch1 = char.Parse(Console.ReadLine());
                char ch2 = char.Parse(Console.ReadLine());

                GetMax(ch1,ch2);
            }
            else if (command == "int")
            {
                string str1 = Console.ReadLine();
                string str2 = Console.ReadLine();

                GetMax(str1, str2);
            }
        }

        static string GetMax(string str1, string str2)
        {
            return String.Compare(str1, str2);
        }

        static int GetMax(int num1, int num2)
        {
            return Math.Max(num1, num2);
        }

        static char GetMax(char ch1, char ch2)
        {
            return Char.

        }
    }
}
