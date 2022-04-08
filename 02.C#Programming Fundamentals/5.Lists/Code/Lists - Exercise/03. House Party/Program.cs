using System;
using System.Collections.Generic;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGuests = int.Parse(Console.ReadLine());

            List<string> list = new List<string>();

            for (int i = 0; i < numberOfGuests; i++)
            {
                string[] arr = Console.ReadLine().Split();

                if (arr.Length == 3)
                {
                    string name = arr[0];

                    if (list.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        list.Add(name);
                    }

                }
                else if(arr.Length == 4)
                {
                    string name = arr[0];

                    if (list.Contains(name))
                    {
                        list.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i]);
                Console.WriteLine();
            }

        }
    }
}
