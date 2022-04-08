using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface IEngineer : IRepair
    {
        IList<IRepair> Repairs { get; }
    }
}
