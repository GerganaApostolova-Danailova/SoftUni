using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface ICitizen
    {
        string Name { get;}

        int Age { get;}

        string Id { get;}

        string Birthdate { get; }
    }
}
