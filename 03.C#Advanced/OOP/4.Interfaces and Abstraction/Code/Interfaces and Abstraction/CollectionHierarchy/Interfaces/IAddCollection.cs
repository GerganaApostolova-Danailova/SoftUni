using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Interfaces
{
    public interface IAddCollection
    {
        List<string> Collection { get; }

        string Add(string item);

    }
}
