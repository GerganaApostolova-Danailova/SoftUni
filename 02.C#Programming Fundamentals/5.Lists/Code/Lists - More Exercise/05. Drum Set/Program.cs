using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Drum_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            double budjet = double.Parse(Console.ReadLine());

            List<int> input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>();

            foreach (var num in input)
            {
                result.Add(num);
            }

           
            double cost = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Hit it again, Gabsy!")
                {
                    break;
                }

                int power = int.Parse(command);

                for (int i = 0; i < result.Count; i++)
                {
                    result[i] -= power;

                    if (result[i] <= 0)
                    {
                        cost = input[i] * 3;

                        if (budjet >= cost)
                        {
                            budjet -= cost;
                            result.RemoveAt(i);
                            result.Insert(i, input[i]);
                           
                        }
                        else
                        {
                            result.RemoveAt(i);
                            input.RemoveAt(i);
                            i--;
                        }
                    }
                }

            }
            Console.WriteLine(string.Join(" ", result));
            Console.WriteLine($"Gabsy has {budjet:f2}lv.");


        }
    }
}
