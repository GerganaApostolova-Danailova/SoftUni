using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Stat
    {
        // endurance, sprint, dribble, passing and shooting

        public const int maxStat = 100;
        public const int minStat = 0;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stat(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get
            {
                return endurance;
            }
            private set
            {
                NotInRange(value, "Endurance");
                endurance = value;
            }
        }

        public int Sprint
        {
            get
            {
                return sprint;
            }
            private set
            {
                NotInRange(value, "Spirit");
                sprint = value;
            }
        }

        public int Dribble
        {
            get
            {
                return dribble;
            }
            private set
            {
                NotInRange(value, "Dribble");
                dribble = value;
            }
        }

        public int Passing
        {
            get
            {
                return passing;
            }
            private set
            {
                NotInRange(value, "Passing");
                passing = value;
            }
        }

        public int Shooting
        {
            get
            {
                return shooting;
            }
            private set
            {
                NotInRange(value, "Shooting");
                shooting = value;
            }
        }

        public double CalculateSkillLevel()
        {
            return (this.Dribble + this.Endurance + this.Passing
                + this.Shooting + this.Sprint) / 5.0;
        }

        private void NotInRange(int value, string currentStatName)
        {
            if (value < minStat || value > maxStat)
            {
                throw new Exception($"{currentStatName} should be between 0 and 100.");
            }
        }



    }
}
