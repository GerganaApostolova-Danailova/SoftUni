using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Repositories.Contracts
{
    public class MotorcycleRepository : Repository<IMotorcycle>
    {
        public override IMotorcycle GetByName(string name)
        {
            var targetMotor = this.Data.Find(m => m.Model == name);

            return targetMotor;
        }
    }
}
