using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SpaceStationRecruitment
{
    class SpaceStation
    {
        public string Name { get; set; }
        public int Capacity { get; set; }

        private List<Astronaut> astronauts;

        public SpaceStation(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.astronauts = new List<Astronaut>();
        }

        public int Count => astronauts.Count;

        public void Add(Astronaut astronaut)
        {
            if (this.astronauts.Count < this.Capacity)
            {
            this.astronauts.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            Astronaut astro = astronauts.FirstOrDefault(x => x.Name == name);

            if (astro == null)
            {
                return false;
            }

            astronauts.Remove(astro);

            return true;
        }

        public Astronaut GetOldestAstronaut()
        {
            int maxAge = astronauts.Max(x => x.Age);
            Astronaut astro = astronauts.First(x => x.Age == maxAge);

            return astro;
        }

        public Astronaut GetAstronaut(string name)
        {
            Astronaut astro = astronauts.FirstOrDefault(x => x.Name == name);

            return astro;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Astronauts working at Space Station {Name}:");

            foreach (var astro in astronauts)
            {
                sb.AppendLine(astro.ToString());
            }

            return sb.ToString().TrimEnd();
        }


    }
}
