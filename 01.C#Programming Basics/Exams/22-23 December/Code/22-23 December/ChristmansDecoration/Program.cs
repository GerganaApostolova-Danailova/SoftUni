using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmansDecoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int buget = int.Parse(Console.ReadLine());

            string command = string.Empty;
            int sumWord = 0;

            while ((command = Console.ReadLine()) != "Stop")
            {
                for (int i = 0; i < command.Length; i++)
                {
                    sumWord += command[i];
                     
                }
                if (sumWord <= buget)
                {
                    Console.WriteLine("Item successfully purchased!");
                }
                else if (sumWord > buget)
                {
                    Console.WriteLine("Not enough money!");
                    break;
                }
            }
            if (command == "Stop")
            {
                Console.WriteLine($"Money left: {buget - sumWord}");
            }
        }
    }
}
