using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            Queue<string> queue = new Queue<string>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                if (command == "Paid")
                {
                    while (queue.Count > 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }

                    count = 0;
                    continue;
                }

                queue.Enqueue(command);
                count++;
            }

            Console.WriteLine($"{count} people remaining.");
        }
    }
}
