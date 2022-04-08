using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> input2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            
            int count = 0;
            int countInput1 = input1.Count;

            if (input1.Count < input2.Count)
            {
                for (int i = 1; i <= input2.Count; i += 2)
                {

                    input1.Insert(i, input2[i - 1 - count]);
                    count++;

                }
                for (int j = input1.Count; j < input2.Count + countInput1; j++)
                {
                    input1.Insert(j, input2[count]);
                    count++;
                }

            }
            else
            {
                for (int i = 1; i < input2.Count * 2; i += 2)
                {

                    input1.Insert(i, input2[i - 1 - count]);
                    count++;

                }
            }

            Console.WriteLine(string.Join(" ", input1));
        }
    }
}

