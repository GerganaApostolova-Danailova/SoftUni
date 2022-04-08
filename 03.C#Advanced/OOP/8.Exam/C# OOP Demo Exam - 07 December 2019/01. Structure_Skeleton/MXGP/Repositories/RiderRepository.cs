using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Repositories
{
    public class RiderRepository : Repository<IRider>
    {
        public override IRider GetByName(string name)
        {
            var targetRider = this.Data.Find(m => m.Name == name);

            return targetRider;
        }
    }
}
