using SpaceStation.Models.Planets;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> planets;

        public PlanetRepository()
        {
            planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models
            => this.planets.AsReadOnly();

        public void Add(IPlanet model)
        {
            planets.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            var returnePlanet = planets.FirstOrDefault(a => a.Name == name);

            return returnePlanet;
        }

        public bool Remove(IPlanet model)
        {
            return planets.Remove(model);
        }
    }
}
