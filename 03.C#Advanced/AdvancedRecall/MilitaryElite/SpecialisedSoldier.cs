using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get { return this.corps; }
            private set
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new ArgumentException("Invalid Corps!");
                }
                this.corps = value;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder
                .AppendLine(base.ToString())
                .AppendLine($"Corps: {this.Corps}");

            return builder.ToString().Trim();
        }
    }
}
