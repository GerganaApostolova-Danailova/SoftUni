using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Gauss__Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();



            List<int> result = new List<int>();

            int current = 0;


            for (int i = 0; i < input.Length/2; i++)
            {
                
                    current = input[i] + input[input.Length - 1 - i];
                    result.Add(current);
                
               
            }
            if (input.Length % 2 != 0)
            {
                result.Add(input[input.Length / 2]);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
