using System;

namespace _001._Data_Type_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            string typeIs = string.Empty;
            int tryInt;
            float tryFloat;
            char tryChar;
            bool tryBool;
            while (input != "END")
            {
                if (int.TryParse(input, out tryInt))
                {
                    typeIs = "integer";
                    Console.WriteLine($"{input} is {typeIs} type");
                }
                else if (float.TryParse(input, out tryFloat))
                {
                    typeIs = "floating point";
                    Console.WriteLine($"{input} is {typeIs} type");
                }
                else if (char.TryParse(input, out tryChar))
                {
                    typeIs = "character";
                    Console.WriteLine($"{input} is {typeIs} type");
                }
                else if (bool.TryParse(input, out tryBool))
                {
                    typeIs = "boolean";
                    Console.WriteLine($"{input} is {typeIs} type");
                }
                else
                {
                    typeIs = "string";
                    Console.WriteLine($"{input} is {typeIs} type");
                }
                input = Console.ReadLine();
            }
        }
    }
}
