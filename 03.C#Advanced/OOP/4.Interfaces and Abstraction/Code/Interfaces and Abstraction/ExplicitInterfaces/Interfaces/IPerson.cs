using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo.Interfaces
{
    public interface IPerson
    {
        int Age { get; }

        string Name { get; }

        string GetName();
    }
}
