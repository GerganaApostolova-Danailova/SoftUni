using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> number = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string messaging = Console.ReadLine();

            int sum = 0;

            for (int i = 0; i < number.Count; i++)
            {
                while (number[i] != 0)
                {
                    sum += number[i] % 10;
                    number[i] /= 10;
                }
                for (int j = 0; j < messaging.Length; j++)
                {
                    if (sum > messaging.Length)
                    {
                        sum -= messaging.Length;
                    }
                    if (j == sum)
                    {
                        Console.Write(messaging[j]);
                       messaging = messaging.Remove(j,1);
                        break;
                    }
                }

                sum = 0;

            }

            

        }
    }
}
