using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface ISoldier
    {
        // id, first name, and last name.

        public int Id { get;}

        public string FirstName { get;}

        public string LastName { get;}
    }
}
