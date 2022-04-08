using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

           Dictionary<int,int> dict = new Dictionary<int,int>();

            for (int i = 0; i < num; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!dict.ContainsKey(number))
                {
                    dict.Add(number,0);
                }
                dict[number]++;
            }

            foreach (var kvp in dict.OrderByDescending(x=>x.Value))
            {
                if (kvp.Value % 2 == 0)
                {
                    Console.WriteLine(kvp.Key);
                    return;
                }
            }
        }
    }
}
