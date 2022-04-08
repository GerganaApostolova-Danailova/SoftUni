using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = new List<int> { 1, 2, 3, 3, 4, 5 };

            //input.RemoveAll(x => x == 3);

            List<int> newList = input.Where(x => x != 3).ToList();

            Console.WriteLine(string.Join(" ",newList));

            //List<int> input = Console.ReadLine()
            //    .Split()
            //    .Select(int.Parse)
            //    .ToList();

            //int capacity = int.Parse(Console.ReadLine());

            //if (capacity <= 0)
            //{
            //    return;
            //}


            //string command = string.Empty;

            //while ((command = Console.ReadLine()) != "end")
            //{
            //    string[] operation = command
            //        .Split()
            //        .ToArray();

            //    if (operation[0] == "Add")
            //    {
            //        int number = int.Parse(operation[1]);

            //        if (number <= capacity)
            //        {
            //            input.Add(number);
            //        }
            //    }
            //    else
            //    {
            //        int number = int.Parse(operation[0]);

            //        if (number <= capacity)
            //        {
            //            for (int i = 0; i < input.Count - 1; i++)
            //            {
            //                if (input[i] + number <= capacity)
            //                {
            //                    input[i] += number;
            //                    break;
            //                }
            //            }
            //        }

            //    }
            //}

            //Console.WriteLine(string.Join(" ", input));
        }
    }
}
