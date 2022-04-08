using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public interface ICitizen
    {
        string Name { get; }

        int Age { get; }

        string Id { get; }

        string Birthday { get; }
    }
}


