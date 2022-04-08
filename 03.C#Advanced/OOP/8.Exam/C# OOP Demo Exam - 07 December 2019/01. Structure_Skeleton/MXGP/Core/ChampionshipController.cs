using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MXGP.Models.Riders;
using MXGP.Models.Motorcycles;
using MXGP.Models.Races;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private Repository<IRider> riderRepository = new RiderRepository();
        private Repository<IMotorcycle> motorcycleRepository = new MotorcycleRepository();
        private Repository<IRace> raceRepository = new RaceRepository();

        //private RiderRepository riderRepository;
        //private RaceRepository raceRepository;
        //private MotorcycleRepository motorcycleRepository;
       
        //public ChampionshipController()
        //{
        //    riderRepository = new RiderRepository();
        //    raceRepository = new RaceRepository();
        //    motorcycleRepository = new MotorcycleRepository();

        //}

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            IRider rider = riderRepository.GetByName(riderName);
            IMotorcycle motorCycle = motorcycleRepository.GetByName(motorcycleModel);

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            if (motorCycle == null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }

            rider.AddMotorcycle(motorCycle);

            return $"Rider {riderName} received motorcycle {motorcycleModel}";
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var testRace = raceRepository.GetByName(raceName);
            var testRider = riderRepository.GetByName(riderName);

            if (testRace == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            else if (testRider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
           
            testRace.AddRider(testRider);

            return $"Rider {riderName} added in {raceName} race.";
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            Motorcycle motorcycle = null;
            if (type == "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
            }
            else if (type == "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
            }
            if (motorcycleRepository.GetAll().Any(x => x.Model == model))
            {
                throw new ArgumentException($"Motorcycle {model} is already created.");
            }
            motorcycleRepository.Add(motorcycle);
            return $"{type}Motorcycle { model} is created.";

            //IMotorcycle motorcycle = motorcycleRepository.GetByName(model);

            //if (motorcycle != null)
            //{
            //    throw new ArgumentException($"Motorcycle {model} is already created");
            //}

            //if (type == "Speed")
            //{
            //    motorcycle = new SpeedMotorcycle(model, horsePower);
            //}
            //else if (type == "Power")
            //{
            //    motorcycle = new PowerMotorcycle(model, horsePower);
            //}

            //motorcycleRepository.Add(motorcycle);

            //return $"{motorcycle.GetType().Name} {model} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            if (raceRepository.GetAll().Any(x => x.Name == name))
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }
            var race = new Race(name, laps);
            raceRepository.Add(race);
            return $"Race {name} is created.";
            //IRace race = new Race(name, laps);
            //IRace tempRace = raceRepository.GetByName(name);

            //if (tempRace != null)
            //{
            //    throw new InvalidOperationException($"Race {name} is already created.");
            //}

            //raceRepository.Add(race);

            //return $"Race {name} is created.";
        }

        public string CreateRider(string riderName)
        {
            if (riderRepository.GetAll().Any(x => x.Name == riderName))
            {
                throw new ArgumentException($"Rider {riderName} is already created.");
            }
            var rider = new Rider(riderName);
            riderRepository.Add(rider);
            return $"Rider {rider.Name} is created.";

            //IRider rider = new Rider(riderName);
            //IRider tempName = riderRepository.GetByName(riderName);

            //if (tempName != null)
            //{
            //    throw new ArgumentException($"Rider {riderName} is already created.");
            //}

            //riderRepository.Add(rider);

            //return $"Rider {riderName} is created.";
        }

        public string StartRace(string raceName)
        {
            if (raceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            var targetRace = raceRepository.GetByName(raceName);
            if (targetRace.Riders.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }
            var bestThreeRiders = targetRace.Riders
                .OrderByDescending(x => x.Motorcycle.CalculateRacePoints(targetRace.Laps))
                .Take(3);

            var sb = new StringBuilder();

            int counter = 0;

            raceRepository.Remove(targetRace);

            foreach (var rider in bestThreeRiders)
            {
                if (counter == 0)
                {
                    sb.AppendLine($"Rider {rider.Name} wins {raceName} race.");
                    rider.WinRace();
                }
                else if (counter == 1)
                {
                    sb.AppendLine($"Rider {rider.Name} is second in {raceName} race.");
                }
                else if (counter == 2)
                {
                    sb.AppendLine($"Rider {rider.Name} is third in {raceName} race.");
                }
                counter++;
            }
            return sb.ToString().TrimEnd();

            //IRace race = raceRepository.GetByName(raceName);

            //if (race == null)
            //{
            //    throw new InvalidOperationException($"Race {raceName} could not be found.");
            //}
            //else if (race.Riders.Count() < 3)
            //{
            //    throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            //}

            //var orderedRiders = race.Riders
            //    .OrderByDescending(r => r.Motorcycle.CalculateRacePoints(race.Laps)).Take(3).ToList();

            //StringBuilder sb = new StringBuilder();

            //sb.AppendLine($"Rider {orderedRiders[0]} wins {raceName} race.")
            //    .AppendLine($"Rider {orderedRiders[1]} is second in {race.Name} race.")
            //    .AppendLine($"Rider {orderedRiders[2]} is third in {race.Name} race.");

            //raceRepository.Remove(race);

            //return sb.ToString().TrimEnd();
        }
    }
}
