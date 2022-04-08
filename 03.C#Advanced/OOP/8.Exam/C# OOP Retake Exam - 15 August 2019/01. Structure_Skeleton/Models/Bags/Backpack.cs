using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Bags
{
    public abstract class Backpack : IBag
    {
        public Backpack()
        {
            Items = new List<string>();
        }

        public ICollection<string> Items { get; private set; }
    }
}
