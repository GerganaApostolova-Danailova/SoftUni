using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Cooking_Factory
{
    class Program
    {
        static void Main(string[] args)
        {

            string command = Console.ReadLine();

            int sum = 0;
            int maxSum = -100000;
            double middleSum = 0;
            double maxMiddleSum = -1000000;
            int maxCount = int.MaxValue;

            List<int> temp = new List<int>();

            while (true)
            {
                if (command == "Bake It!")
                {
                    break;
                }

                List<int> currunt = command
                    .Split("#")
                    .Select(int.Parse)
                    .ToList();


                for (int i = 0; i < currunt.Count; i++)
                {
                    sum += currunt[i];
                }

                middleSum = sum * 1.0 / currunt.Count;

                if (middleSum > maxMiddleSum)
                {
                    maxMiddleSum = middleSum;
                    middleSum = 0;

                }

                if (sum > maxSum)
                {
                    maxSum = sum;

                    temp.Clear();

                    for (int j = 0; j < currunt.Count; j++)
                    {
                        temp.Add(currunt[j]);
                    }
                    sum = 0;

                if (currunt.Count < maxCount)
                {
                    maxCount = currunt.Count;
                }

                }
                else if (sum == maxSum)
                {
                    if (middleSum > maxMiddleSum)
                    {
                        maxMiddleSum = middleSum;
                        temp.Clear();
                        for (int j = 0; j < currunt.Count; j++)
                        {
                            temp.Add(currunt[j]);
                        }
                        middleSum = 0;

                    }
                    else if (middleSum == maxMiddleSum)
                    {
                        if (currunt.Count < maxCount)
                        {
                            maxCount = currunt.Count;
                            temp.Clear();
                            for (int j = 0; j < currunt.Count; j++)
                            {
                                temp.Add(currunt[j]);
                            }

                        }
                    }
                    sum = 0;
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"Best Batch quality: {maxSum}");
            Console.WriteLine(string.Join(" ", temp));
        }
    }
}
