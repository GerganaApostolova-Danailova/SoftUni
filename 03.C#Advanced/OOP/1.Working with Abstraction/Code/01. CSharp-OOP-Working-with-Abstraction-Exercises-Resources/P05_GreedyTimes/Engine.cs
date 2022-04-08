using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_GreedyTimes
{
    public class Engine
    {
        public Engine()
        {
            this.bag = new Dictionary<string, Dictionary<string, long>>();
        }

        private Dictionary<string, Dictionary<string, long>> bag;
        private long gold;
        private long gem;
        private long cash;
        private string itemType;
        private string name;
        private long quantity;

        public void Run()
        {
            long capasityOfBag = long.Parse(Console.ReadLine());

            string[] items = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < items.Length; i += 2)
            {
                name = items[i];
                quantity = long.Parse(items[i + 1]);

                DefineItemTipe(name);


                if (itemType == "")
                {
                    continue;
                }
                else if (capasityOfBag < bag.Values.Select(x => x.Values.Sum()).Sum() + quantity)
                {
                    continue;
                }

                switch (itemType)
                {
                    case "Gem":
                        if (!bag.ContainsKey(itemType))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (quantity > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[itemType].Values.Sum() + quantity > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;

                    case "Cash":
                        if (!bag.ContainsKey(itemType))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (quantity > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[itemType].Values.Sum() + quantity > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                AddItemToBag(name, quantity);
            }

            PrintItem();
        }

        private void PrintItem()
        {
            foreach (var x in bag)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");

                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }

        private void AddItemToBag(string name, long quantity)
        {
            if (!bag.ContainsKey(itemType))
            {
                bag[itemType] = new Dictionary<string, long>();
            }

            if (!bag[itemType].ContainsKey(name))
            {
                bag[itemType][name] = 0;
            }

            bag[itemType][name] += quantity;

            if (itemType == "Gold")
            {
                gold += quantity;
            }
            else if (itemType == "Gem")
            {
                gem += quantity;
            }
            else if (itemType == "Cash")
            {
                cash += quantity;
            }
        }

        private void DefineItemTipe(string name)
        {
            if (name.Length == 3)
            {
                itemType = "Cash";
            }
            else if (name.ToLower().EndsWith("gem"))
            {
                itemType = "Gem";
            }
            else if (name.ToLower() == "gold")
            {
                itemType = "Gold";
            }
        }
    }
}
