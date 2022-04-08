using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();

            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int bombNum = arr[0];
            int power = arr[1];

            int sum = 0;

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] == bombNum)
                {
                    if ((i - power) < 0 && (i + power) <= input.Count - 1)
                    {
                        int stay = input.Count - ((input.Count) - i);
                        input.RemoveRange(0, stay + power + 1);
                    }
                    else if (i - power >= 0 && (i + power)>input.Count-1)
                    {
                        int stay = (input.Count - 1) - i;
                        input.RemoveRange(i - power,power + stay +1);
                    }
                    else
                    {
                        input.RemoveRange(i - power, power * 2 + 1);
                        i = -1;

                    }

                }
            }
            for (int i = 0; i < input.Count; i++)
            {
                sum += input[i];
            }

            Console.WriteLine(sum);
        }
    }
}
