using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _07._Store_Boxes
{
    class Program
    {
        class Item
        {
            public string Name { get; set; }
            public double Price { get; set; }

        }

        class Box
        {
            public long SerialNumber { get; set; }
            public Item Item { get; set; }
            public int ItemQuantity { get; set; }
            public double PriceForABox { get; set; }

        }
        class FinalListElementsItemAndPrice
        {
            public long serialNumber;
            public string ItemName;
            public double ItemPrice;
            public int ItemQuantity;
            public double BoxPrice;
        }

        static void Main(string[] args)
        {

            List<Box> boxes = new List<Box>();
            List<Item> items = new List<Item>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] input = command
                     .Split();

                long serialNumber = long.Parse(input[0]);
                string itemName = input[1];
                int itemQuantity = int.Parse(input[2]);
                double itemPrice = double.Parse(input[3]);

                double price = itemQuantity * itemPrice;


                Box currentBoxes = new Box();
                Item currentItem = new Item();


                currentItem.Name = itemName;
                currentItem.Price = itemPrice;
                currentBoxes.SerialNumber = serialNumber;
                currentBoxes.ItemQuantity = itemQuantity;
                currentBoxes.PriceForABox = price;

                items.Add(currentItem);
                boxes.Add(currentBoxes);

            }

            List<FinalListElementsItemAndPrice> finalList = new List<FinalListElementsItemAndPrice>();

            for (int i = 0; i < boxes.Count; i++)
            {
                FinalListElementsItemAndPrice finalListElements = new FinalListElementsItemAndPrice();

                finalListElements.serialNumber = boxes[i].SerialNumber;
                finalListElements.ItemName = items[i].Name;
                finalListElements.ItemPrice = items[i].Price;
                finalListElements.ItemQuantity = boxes[i].ItemQuantity;
                finalListElements.BoxPrice = boxes[i].PriceForABox;

                finalList.Add(finalListElements);
            }

            List<FinalListElementsItemAndPrice> orderedList = finalList
                .OrderByDescending(x => x.BoxPrice)
                .ToList();

            foreach (var item in orderedList)
            {
                Console.WriteLine(item.serialNumber);
                Console.WriteLine($"-- {item.ItemName} - ${item.ItemPrice:f2}: {item.ItemQuantity}");
                Console.WriteLine($"-- ${item.BoxPrice:f2}");
               
            }
        }
    }
}
