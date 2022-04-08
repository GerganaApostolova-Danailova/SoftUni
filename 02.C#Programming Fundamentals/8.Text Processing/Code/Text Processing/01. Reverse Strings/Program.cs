using System;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {

            string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string reversed = string.Empty;

                for (int i = command.Length - 1; i >= 0; i--)
                {
                    reversed += command[i];
                }

                Console.WriteLine($"{command} = {reversed}");
            }
        }
    }
}
