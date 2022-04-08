using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : Repair, IEngineer

    {

        public Engineer(string partName, int hoursWorked)
            : base(partName, hoursWorked)
        {
            this.Repairs = new List<Repair>();
        }

        public IList<IRepair> Repairs { get; private set; }
    }
}
