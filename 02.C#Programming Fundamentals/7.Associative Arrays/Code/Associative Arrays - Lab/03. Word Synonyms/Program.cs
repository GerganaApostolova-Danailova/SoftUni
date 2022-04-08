using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> synonims = new Dictionary<string, List<string>>();

            for (int i = 0; i <  num; i++)
            {
                string key = Console.ReadLine();
                string value = Console.ReadLine();


                if (!synonims.ContainsKey(key))
                {
                    
                    synonims.Add(key, new List<string>());
                    synonims[key].Add(value);

                }
                else
                {
                    synonims[key].Add(value);

                }
            }

            foreach (var synonim in synonims)
            {
                Console.WriteLine($"{synonim.Key} - {string.Join(", ",synonim.Value)} ");
               
            }
        }
    }
}
