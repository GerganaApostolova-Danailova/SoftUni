using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> help = new List<int>();


            while (input.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());


                if (index >= 0 && index <= input.Count - 1)
                {
                    int currentNUmber = input[index];

                            help.Add(currentNUmber);
                            input.RemoveAt(index);

                    for (int i = 0; i < input.Count; i++)
                    {
                        if (input[i] <= currentNUmber)
                        {
                            input[i] += currentNUmber;
                        }
                        else
                        {
                            input[i] -= currentNUmber;
                        }
                    }
                }
                else if (index < 0)
                {
                    int currentNUmber = input[0];

                    help.Add(currentNUmber);
                    input.RemoveAt(0);
                    input.Add(input[input.Count - 1]);

                    for (int i = 0; i < input.Count; i++)
                    {
                        if (input[i] <= currentNUmber)
                        {
                            input[i] += currentNUmber;
                        }
                        else
                        {
                            input[i] -= currentNUmber;
                        }
                    }
                }
                else if (index > input.Count - 1)
                {
                    int currentNUmber = input[input.Count - 1];

                    help.Add(currentNUmber);
                    input.RemoveAt(input.Count - 1);
                    input.Add(input[0]);

                    for (int i = 0; i < input.Count; i++)
                    {
                        if (input[i] <= currentNUmber)
                        {
                            input[i] += currentNUmber;
                        }

                        else
                        {
                            input[i] -= currentNUmber;
                        }
                    }
                }
            }
            int sum = 0;

            for (int i = 0; i < help.Count; i++)
            {
                sum += help[i];
            }

            Console.WriteLine(sum);
            
        }
    }
}
