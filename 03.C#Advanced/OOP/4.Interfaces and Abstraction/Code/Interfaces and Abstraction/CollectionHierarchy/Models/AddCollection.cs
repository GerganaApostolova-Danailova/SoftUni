using System;
using System.Collections.Generic;
using System.Text;
using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy.Interfaces
{
    public class AddCollection : IAddCollection
    {
        public AddCollection()
        {
            this.Collection = new List<string>();
        }

        public List<string> Collection { get; }

        public string Add(string item)
        {
            this.Collection.Add(item);

            return (this.Collection.Count-1).ToString();
        }
    }
}
