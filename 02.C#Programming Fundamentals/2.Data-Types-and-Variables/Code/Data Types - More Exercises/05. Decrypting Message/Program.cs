using System;

namespace _05._Decrypting_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());



            int digit = 0;
            string word = string.Empty;


            for (int i = 1; i <= n; i++)
            {
                char letter = char.Parse(Console.ReadLine());

                
                digit = (letter + key);

                word += (char)digit;
                
            }

            
            Console.Write(word);

        }
    }
}
