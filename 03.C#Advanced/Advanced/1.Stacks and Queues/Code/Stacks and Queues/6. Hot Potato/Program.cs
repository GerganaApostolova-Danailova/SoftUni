using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _6._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine()
                .Split();

            int num = int.Parse(Console.ReadLine());

            Queue<string> winChildren = new Queue<string>(children);

            while (winChildren.Count != 1)
            {
                for (int i = 1; i < num; i++)
                {
                    winChildren.Enqueue(winChildren.Dequeue());
                }
                Console.WriteLine($"Removed {winChildren.Dequeue()}");
            }

            Console.WriteLine($"Last is {winChildren.Dequeue()}");
        }
    }
}
