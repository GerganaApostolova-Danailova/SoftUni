using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        
        public string Name
        {
            get
            {
                return 
                    name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A name should not be empty.");
                }
                name = value;
            }
        }

        public Player(string name, Stat stats)
        {
            Name = name;
            Stat = Stat;
        }

        public Stat Stat { get; private set; }

        public double CalculateStat
            => this.Stat.CalculateSkillLevel();

    }
}
