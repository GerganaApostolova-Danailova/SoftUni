using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();
            

            while (true)
            {
            string resource = Console.ReadLine();

                if (resource == "stop")
                {
                    break;
                }

                int quantity = int.Parse(Console.ReadLine());

                if (resources.ContainsKey(resource))
                {
                    resources[resource] += quantity;
                }
                else
                {
                    resources.Add(resource, quantity);
                }

            }
            foreach (var resorce in resources)
            {
                Console.WriteLine($"{resorce.Key} -> {resorce.Value}");
            }
        }
    }
}
