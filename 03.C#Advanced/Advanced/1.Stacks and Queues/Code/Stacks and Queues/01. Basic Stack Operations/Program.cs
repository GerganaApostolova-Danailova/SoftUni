using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _01._Basic_Stack_Operations
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

            Stack<int> stackPlaying = new Stack<int>(input);

            for (int i = 0; i < popedElements; i++)
            {
                stackPlaying.Pop();
            }

            if (stackPlaying.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stackPlaying.Contains(lookingForElements))
            {
                Console.WriteLine("true");
            }
            else if(!stackPlaying.Contains(lookingForElements))
            {
                Console.WriteLine(stackPlaying.Min());
            }
        }
    }
}
