using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private IAstronaut astronaut;
        private IPlanet planet;
        private IMission mission;
       
        private AstronautRepository astroRepository;
        private PlanetRepository planetRepository;
        private int exploredPlanetCount;

        public Controller()
        {
            astroRepository = new AstronautRepository();
            planetRepository = new PlanetRepository();

        }

        public string AddAstronaut(string type, string astronautName)
        {
            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }
            else if (type != "Biologist" && type != "Geodesist" && type != "Meteorologist")
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }

            astroRepository.Add(astronaut);

            return $"Successfully added {astronaut.GetType().Name}: {astronautName}!";

        }

        public string AddPlanet(string planetName, params string[] items)
        {
            planet = new Planet(planetName);

            if (items.Length != 0 )
            {
                foreach (var item in items)
                {
                    planet.Items.Add(item);
                }
            }

            planetRepository.Add(planet);
            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            var suitableAstronaut = astroRepository
                .Models
                .Where(x => x.Oxygen > 60)
                .ToList();

            if (suitableAstronaut.Count == 0)
            {
                throw new 
                    InvalidOperationException("You need at least one astronaut to explore the planet");
            }

            var planetExplore = planetRepository.FindByName(planetName);

            mission.Explore(planetExplore, suitableAstronaut);

            int deadAstronauts = astroRepository.Models
                .Where(x => x.Oxygen <= 0).Count();

            exploredPlanetCount++;

            return $"Planet: {planetName} was explored! Exploration finished with {deadAstronauts} dead astronauts!";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{exploredPlanetCount} planets were explored!");
                sb.AppendLine("Astronauts info:");

            foreach (var astronaut in astroRepository.Models)
            {
                sb.AppendLine(astronaut.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            var astro = astroRepository.FindByName(astronautName);

            if (astro == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }

            astroRepository.Remove(astro);
            return $"Astronaut {astronautName} was retired!";
        }
    }
}
