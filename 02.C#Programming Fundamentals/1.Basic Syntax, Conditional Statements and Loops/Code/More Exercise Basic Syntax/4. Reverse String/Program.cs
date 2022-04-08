using System;

namespace _4._Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string comment = Console.ReadLine();

            string reversed = string.Empty;

            for (int i = comment.Length - 1; i >= 0; --i)
            {
                reversed += comment[i];
                
            }
            Console.Write(reversed);
        }
    }
}
