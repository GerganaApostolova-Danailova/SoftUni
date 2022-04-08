using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Soldier : ISoldier
    {
        public Soldier(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");

            return builder.ToString().Trim();
        }
    }
}
