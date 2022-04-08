using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        private string trainerName;
        private int numberOfBadges;
        private List<Pokemon> pokemon;

        public Trainer(string trainerName)
        {
            TrainerName = trainerName;
            NumberOfBadges = 0;
            Pokemon = new List<Pokemon>();
        }

        public string TrainerName
        {
            get { return trainerName; }
            set { trainerName = value; }
        }

        public int NumberOfBadges
        {
            get { return numberOfBadges; }
            set { numberOfBadges = value; }
        }

        public List<Pokemon> Pokemon
        {
            get { return pokemon; }
            set { pokemon = value; }
        }

    }
}
