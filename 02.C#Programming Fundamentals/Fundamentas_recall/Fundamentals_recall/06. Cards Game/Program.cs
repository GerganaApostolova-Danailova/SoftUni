using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerCards = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();

            List<int> secondPlayerCards = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();

            while (firstPlayerCards.Any() && secondPlayerCards.Any())
            {
                if (firstPlayerCards[0] == secondPlayerCards[0])
                {
                    firstPlayerCards.RemoveAt(0);
                    secondPlayerCards.RemoveAt(0);
                    continue;
                }
                else if (firstPlayerCards[0] > secondPlayerCards[0])
                {
                    firstPlayerCards.Add(secondPlayerCards[0]);
                    firstPlayerCards.Add(firstPlayerCards[0]);
                    firstPlayerCards.RemoveAt(0);
                    secondPlayerCards.RemoveAt(0);
                    continue;
                }
                else if (firstPlayerCards[0] < secondPlayerCards[0])
                {
                    secondPlayerCards.Add(firstPlayerCards[0]);
                    secondPlayerCards.Add(secondPlayerCards[0]);
                    firstPlayerCards.RemoveAt(0);
                    secondPlayerCards.RemoveAt(0);
                    continue;
                }
            }

            if (firstPlayerCards.Any())
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayerCards.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayerCards.Sum()}");

            }
        }
    }
}
