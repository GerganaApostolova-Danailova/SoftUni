using System;
using System.Linq;
using System.Collections.Generic;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(input);

            while (queue.Count > 0)
            {
                if (queue.Peek() % 2 != 0)
                {
                    queue.Dequeue();
                }
                else if (queue.Count == 1)
                {
                    Console.Write(queue.Dequeue());
                }
                else if(queue.Count > 1 && queue.Peek() % 2 == 0)
                {
                    Console.Write(queue.Dequeue() + ", ");
                }
            }
        }
    }
}
