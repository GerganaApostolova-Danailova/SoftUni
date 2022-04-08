using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;


namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] NSX = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int pushedElements = NSX[0];
            int popedElements = NSX[1];
            int lookingForElements = NSX[2];

            Queue<int> stackPlaying = new Queue<int>(input);

            for (int i = 0; i < popedElements; i++)
            {
                stackPlaying.Dequeue();
            }

            if (stackPlaying.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stackPlaying.Contains(lookingForElements))
            {
                Console.WriteLine("true");
            }
            else if (!stackPlaying.Contains(lookingForElements))
            {
                Console.WriteLine(stackPlaying.Min());
            }
        }
    }
}
