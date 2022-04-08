using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Spaceship_Crafting
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            Stack<int> items = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            SortedDictionary<string, int> materialForShip = new SortedDictionary<string, int>();

            materialForShip.Add("Glass", 0);
            materialForShip.Add("Aluminium", 0);
            materialForShip.Add("Lithium", 0);
            materialForShip.Add("Carbon fiber", 0);


            while (liquids.Count > 0 && items.Count > 0)
            {
                int currentLiquid = liquids.Dequeue();
                int currentItem = items.Pop();

                int currentMaterialValue = currentLiquid + currentItem;

                if (currentMaterialValue == 25)
                {
                    materialForShip["Glass"]++;
                }
                else if (currentMaterialValue == 50)
                {
                    materialForShip["Aluminium"]++;
                }
                else if (currentMaterialValue == 75)
                {
                    materialForShip["Lithium"]++;
                }
                else if (currentMaterialValue == 100)
                {
                    materialForShip["Carbon fiber"]++;
                }
                else
                {
                    currentItem += 3;
                    items.Push(currentItem);
                }
            }

            var sortedForShip = materialForShip
                .Where(x => x.Value >= 1)
                .ToDictionary(x => x.Key, y => y.Value);

            if (sortedForShip.Count == 4)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (liquids.Count > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }


            if (items.Count > 0)
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", items)}");
            }
            else
            {
                Console.WriteLine("Physical items left: none");
            }

            foreach (var item in materialForShip)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
