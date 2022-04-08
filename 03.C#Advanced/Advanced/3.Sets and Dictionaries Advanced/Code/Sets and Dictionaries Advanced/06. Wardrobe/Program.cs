using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < num; i++)
            {
                string[] line = Console.ReadLine()
                    .Split(" -> ");

                string color = line[0];
                string[] clothes = line[1]
                    .Split(",");

                if (!dict.ContainsKey(color))
                {
                    dict.Add(color, new Dictionary<string,int>());
                }

                for (int j = 0; j < clothes.Length; j++)
                {
                    string clothe = clothes[j];

                    if (!dict[color].ContainsKey(clothe))
                    {
                        dict[color].Add(clothe, 0);
                    }
                    dict[color][clothe]++;
                }
            }

            string[] finalClothes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string finalColor = finalClothes[0];
            string finalClothe = finalClothes[1];

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} clothes:");

                foreach (var kvp2 in kvp.Value)
                {
                    if (kvp.Key == finalColor && kvp2.Key == finalClothe)
                    {
                        Console.WriteLine($"* {kvp2.Key} - {kvp2.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {kvp2.Key} - {kvp2.Value}");
                    }
                }
            }
        }
    }
}
