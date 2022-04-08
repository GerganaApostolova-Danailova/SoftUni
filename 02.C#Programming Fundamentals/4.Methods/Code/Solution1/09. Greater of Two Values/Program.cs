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

                int maxNum = GetMaxInt(num1, num2);

                Console.WriteLine(maxNum);
            }
            else if (command == "char")
            {
                char num1 = char.Parse(Console.ReadLine());
                char num2 = char.Parse(Console.ReadLine());

                char maxChar = GetMaxChar(num1, num2);

                Console.WriteLine(maxChar);
            }
            else if (command == "string")
            {
                string num1 = Console.ReadLine();
                string num2 = Console.ReadLine();
               

                string maxString = GetMaxString(num1, num2);

                Console.WriteLine(maxString);
            }



        }

        static string GetMaxString(string num1, string num2)
        {
            if (num1.CompareTo(num2) >= 0)
            {
                return num1;
            }
            else
            {
                return num2;
            }
        }

        static char GetMaxChar(char num1, char num2)
        {
            if (num1 > num2)
            {
                return num1;
            }
            else
            {
                return num2;
            }
        }

        static int GetMaxInt(int num1, int num2)
        {
            if (num1 > num2)
            {
                return num1;
            }
            else
            {
                return num2;
            }
        }

    }
}
