using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _5._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();

            while (true)
            {
                string name = Console.ReadLine();

                if (name == "Paid")
                {
                    while (queue.Count != 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                    queue.Clear();
                    name = Console.ReadLine();
                }
                if (name == "End")
                {
                    break;
                }

                queue.Enqueue(name);
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
