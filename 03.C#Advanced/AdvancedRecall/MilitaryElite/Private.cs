using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{base.ToString()}");
            sb.Append($" Salary: {this.Salary:f2}");
           
            return sb.ToString().TrimEnd();
        }
    }
}
