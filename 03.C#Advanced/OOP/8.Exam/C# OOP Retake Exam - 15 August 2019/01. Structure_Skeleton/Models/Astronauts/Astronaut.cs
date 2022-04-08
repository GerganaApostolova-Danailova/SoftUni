using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;

        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new
                        ArgumentNullException("Astronaut name cannot be null or empty.");
                }

                name = value;
            }
        }

        public double Oxygen
        {
            get { return oxygen; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot create Astronaut with negative oxygen!");
                }

                oxygen = value;
            }
        }

        public bool CanBreath
            => this.oxygen != 0.0;

        public IBag Bag { get; private set; }

        public virtual void Breath()
        {
            double resultOxygen = Oxygen - 10.0;

            if (resultOxygen < 0)
            {
                Oxygen = 0;
            }
            else
            {
                Oxygen = resultOxygen;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string result = Bag.Items.Count == 0
                ? "None" : string.Join(", ", Bag.Items);

            sb.AppendLine($"Name: {Name}")
                .AppendLine($"Oxygen: {Oxygen}")
                .AppendLine($"Bag items: {result}");

            return sb.ToString().TrimEnd();
        }
    }
}
