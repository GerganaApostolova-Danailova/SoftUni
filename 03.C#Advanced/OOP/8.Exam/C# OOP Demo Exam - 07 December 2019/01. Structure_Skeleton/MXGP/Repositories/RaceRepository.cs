using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Repositories
{
    public class RaceRepository : Repository<IRace>
    {
        public override IRace GetByName(string name)
        {
            var targetRace = this.Data.Find(m => m.Name == name);

            return targetRace;
        }
    }

}
