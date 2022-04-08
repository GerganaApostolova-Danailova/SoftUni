using System;

namespace _07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int repeatNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < repeatNum; i++)
            {
                string text = GetText(command);
                Console.Write(text);
            }
        }

       static string GetText(string text)
        {
            return text;
        }
    }
}
