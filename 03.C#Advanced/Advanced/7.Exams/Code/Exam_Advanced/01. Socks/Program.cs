using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Socks
{
    class Program
    {
        public static bool leftIsBigger(int currentLeft, int currentRight)
        {
            if (currentLeft > currentRight)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            int[] leftSocksInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] rightSocksInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> leftSocks = new Stack<int>(leftSocksInput);
            Queue<int> rightSocks = new Queue<int>(rightSocksInput);

            List<int> pears = new List<int>();

            while (leftSocks.Count != 0 && rightSocks.Count != 0)
            {
                int currentLeft = leftSocks.Peek();
                int currentRight = rightSocks.Peek();

                bool leftIsBiggest = leftIsBigger(currentLeft, currentRight);

                if (currentLeft > currentRight)
                {
                    int currentPair = leftSocks.Pop() + rightSocks.Dequeue();

                    pears.Add(currentPair);
                    continue;
                }
                else if (currentLeft == currentRight)
                {
                    currentLeft++;
                    rightSocks.Dequeue();
                    leftSocks.Pop();
                    leftSocks.Push(currentLeft);
                    continue;
                }
                else
                {
                    bool isEmpty = false;
                    bool isEqueal = false;

                    while (currentLeft <= currentRight)
                    {
                        leftSocks.Pop();

                        if (leftSocks.Count != 0)
                        {
                            currentLeft = leftSocks.Peek();

                            if (currentLeft == currentRight)
                            {
                                currentLeft++;
                                rightSocks.Dequeue();
                                leftSocks.Pop();
                                leftSocks.Push(currentLeft);
                                isEmpty = true;
                                isEqueal = true;
                                continue;
                            }
                        }
                        else
                        {
                            isEmpty = true;
                            break;
                        }
                    }
                    if (isEqueal)
                    {
                        continue;
                    }
                    if (!isEmpty && currentLeft > currentRight)
                    {
                        int currentPair = leftSocks.Pop() + rightSocks.Dequeue();

                        pears.Add(currentPair);
                        continue;

                    }
                    break;
                }
            }

            Console.WriteLine(pears.Max());
            Console.WriteLine(string.Join(" ", pears));
        }

    }

}
