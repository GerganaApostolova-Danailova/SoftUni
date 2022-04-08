using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Car_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] totalTime = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            double sumLeft = 0;
            double sumRight = 0;

            
            for (
int i = 0; i < totalTime.Length / 2; i++)
            {
                if (totalTime[i] == 0)
                {
                    sumLeft *= 0.8;
                }

                sumLeft += totalTime[i];
            }

            for (int j = totalTime.Length -1; j >= (totalTime.Length / 2) + 1; j--)
            {
                if (totalTime[j] == 0)
                {
                    sumRight *= 0.8;
                }

                sumRight += totalTime[j];
            }

            if (sumLeft > sumRight)
            {
                Console.WriteLine($"The winner is right with total time: {sumRight}");
            }
            else if (sumLeft < sumRight)
            {
                Console.WriteLine($"The winner is left with total time: {sumLeft}");
            }
        }
    }
}
