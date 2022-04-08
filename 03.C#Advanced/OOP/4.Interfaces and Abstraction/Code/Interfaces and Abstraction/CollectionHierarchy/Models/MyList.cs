using System;
using System.Collections.Generic;
using System.Text;
using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy.Models
{
    public class MyList : IMyList
    {
        public List<string> Collection { get; }

        public MyList()
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
            string remuveItem = this.Collection[0];

            this.Collection.Remove(remuveItem);

            return remuveItem;
        }

        public int Used()
        {
            return this.Collection.Count;
        }
    }
}
