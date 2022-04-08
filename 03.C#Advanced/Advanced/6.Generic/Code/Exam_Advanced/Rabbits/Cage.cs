using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Rabbits
{
    public class Cage
    {
        public string Name { get; private set; }
        public int Capacity { get; private set; }

        private List<Rabbit>rabbits;

        public Cage(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            rabbits = new List<Rabbit>();
        }

        public int Count => rabbits.Count;

        public void Add(Rabbit rabbit)
        {
            if (this.rabbits.Count < this.Capacity)
            {
                this.rabbits.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            Rabbit rabit = rabbits.FirstOrDefault(x => x.Name == name);

            if (rabit == null)
            {
                return false;
            }

            rabbits.Remove(rabit);

            return true;
        }

        public void RemoveSpecies(string species)
        {
            Rabbit rabitToRemuve = rabbits.FirstOrDefault(x => x.Species == species);
            rabbits.Remove(rabitToRemuve);
        }

        public Rabbit SellRabbit(string name)
        {
            Rabbit sellRabbit = rabbits.FirstOrDefault(x => x.Name == name);
            sellRabbit.Available = false;
            return sellRabbit;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            List<Rabbit> helprabbits = new List<Rabbit>();

            foreach (var rab in rabbits)
            {
                if (rab.Species == species && rab.Available == true)
                {
                    helprabbits.Add(rab);
                }
            }

            return helprabbits.ToArray();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Rabbits available at {this.Name}:");

            foreach (var rab in rabbits.Where(x => x.Available == true))
            {
                sb.AppendLine(rab.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
