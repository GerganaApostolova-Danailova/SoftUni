using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Store_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            List<Box> boxes = new List<Box>();

            while ((command = Console.ReadLine())!= "end")
            {
                string[] input = command.Split();

                string serialNumber = input[0];
                string itemName = input[1];
                int quantity = int.Parse(input[2]);
                decimal itemPrice = decimal.Parse(input[3]);

                decimal boxPrice = itemPrice * quantity;

                Box box = new Box(serialNumber,quantity, boxPrice);
                box.Item.Name = itemName;
                box.Item.Price = itemPrice;

                boxes.Add(box);
            }

            var orderedBoxByPrice = boxes.OrderByDescending(x => x.BoxPrice);

            foreach (var box in orderedBoxByPrice)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.Quantity}");
                Console.WriteLine($"-- ${box.BoxPrice:f2}");
            }
        }
        public class Item
        {
            public string Name { get; set; }

            public decimal Price { get; set; }
        }

        public class Box
        {
            public Box(string serialNumber, int quantity, decimal boxPrice)
            {
                Item = new Item();
                SerialNumber = serialNumber;
                Quantity = quantity;
                BoxPrice = boxPrice;
            }

            public string SerialNumber { get; set; }

            public Item Item { get; set; }

            public int Quantity { get; set; }

            public decimal BoxPrice { get; set; }
        }
    }
}
