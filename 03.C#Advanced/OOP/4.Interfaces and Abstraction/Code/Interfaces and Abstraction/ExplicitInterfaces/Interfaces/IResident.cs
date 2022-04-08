using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo.Interfaces
{
    public interface IResident
    {
        string Country { get;}

        string Name { get; }

        string GetName();
    }
}
