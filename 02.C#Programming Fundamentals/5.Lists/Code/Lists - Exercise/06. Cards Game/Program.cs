using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> player1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> player2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int sum = 0;

            for (int i = 0; i < player1.Count; i++)
            {
               
                if (player1[i] > player2[i])
                {
                    player1.Add(player1[i]);
                    player1.Add(player2[i]);
                    player1.RemoveAt(i);
                    player2.RemoveAt(i);

                    bool isEmpty = !player2.Any();

                    if (isEmpty)
                    {
                        for (int j = 0; j < player1.Count; j++)
                        {
                            sum += player1[j];
                        }
                        Console.WriteLine($"First player wins! Sum: {sum}");
                        return;
                    }
                    i = -1;
                }
                else if (player2[i] > player1[i])
                {
                    player2.Add(player2[i]);
                    player2.Add(player1[i]);
                    player1.RemoveAt(i);
                    player2.RemoveAt(i);

                    bool isEmpty = !player1.Any();

                    if (isEmpty)
                    {
                        for (int j = 0; j < player2.Count; j++)
                        {
                            sum += player2[j];
                        }
                        Console.WriteLine($"Second player wins! Sum: {sum}");
                        return;
                    }
                    i = -1;
                }
                else
                {
                    player1.RemoveAt(i);
                    player2.RemoveAt(i);

                    bool isEmpty1 = !player1.Any();

                    if (isEmpty1)
                    {
                        for (int j = 0; j < player2.Count; j++)
                        {
                            sum += player2[j];
                        }
                        Console.WriteLine($"Second player wins! Sum: {sum}");
                        return;
                    }

                    bool isEmpty2 = !player2.Any();

                    if (isEmpty1)
                    {
                        for (int k = 0; k < player2.Count; k++)
                        {
                            sum += player2[k];
                        }
                        Console.WriteLine($"Second player wins! Sum: {sum}");
                        return;
                    }
                    i = -1;

                }
            }




        }
    }
}
