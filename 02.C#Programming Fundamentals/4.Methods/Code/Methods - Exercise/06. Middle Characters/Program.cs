using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            PrintSingelChar(command);

        }

        static void PrintSingelChar(string command)
        {
           
                if ((command.Length) % 2 == 0)
                {
                Console.WriteLine($"{command[((command.Length) / 2) - 1]}{command[((command.Length) / 2)]}");
            }
                else
                {
                    Console.WriteLine(command [(command.Length)/2] );
                }
            
        }
    }
}
