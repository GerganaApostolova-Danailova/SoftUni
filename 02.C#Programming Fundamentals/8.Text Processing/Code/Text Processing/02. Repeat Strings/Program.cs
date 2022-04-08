using System;
using System.Text;

namespace _02._Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split();

           string result = string.Empty;

            foreach (var word in words)
            {
                int count = word.Length;

                for (int i = 0; i < count; i++)
                {
                    result += word;
                }
            }

            

            Console.WriteLine(result);
        }
    }
}
