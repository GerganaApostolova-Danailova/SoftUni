using System;
using System.Collections.Generic;
using System.Linq;


namespace _05._Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < num; i++)
            {
                string name = Console.ReadLine();

                set.Add(name);
            }
            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }
    }
}
