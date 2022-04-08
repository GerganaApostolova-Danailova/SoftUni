using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int, int> addFunc = nums => nums += 1;
            Func<int, int> multiplyFunc = nums => nums *= 2;
            Func<int, int> subtractFunc = nums => nums -= 1;
            Action<int[]> printResult = number => Console.WriteLine(string.Join(" ", number));


            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }
                if (command == "add")
                {
                   numbers = numbers.Select(addFunc).ToArray();
                }
                else if (command == "multiply")
                {
                    numbers = numbers.Select(multiplyFunc).ToArray();
                }
                else if (command == "subtract")
                {
                    numbers = numbers.Select(subtractFunc).ToArray();
                }
                else if (command == "print")
                {
                    printResult(numbers);
                }

            }
        }
    }
}
