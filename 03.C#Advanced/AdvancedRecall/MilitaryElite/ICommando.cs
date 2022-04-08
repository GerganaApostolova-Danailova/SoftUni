using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface ICommando : IMission
    {
        IList<IMission> Missions { get; }

    }
}
