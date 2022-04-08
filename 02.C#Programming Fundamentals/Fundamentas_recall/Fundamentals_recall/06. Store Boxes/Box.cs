using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Store_Boxes
{
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
