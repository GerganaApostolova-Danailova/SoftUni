using System;
using System.Collections.Generic;
using System.Text;
using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        public List<string> Collection { get; }

        public AddRemoveCollection()
        {
            this.Collection = new List<string>();
        }

        public string Add(string item)
        {
            this.Collection.Insert(0, item);

            return "0";
        }

        public string Remuve()
        {
            string remuveItem = this.Collection[Collection.Count - 1];

            this.Collection.Remove(remuveItem);

            return remuveItem;
        }
    }
}
