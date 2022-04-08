using AquaShop.Models;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Core.Contracts
{
    public class Controller : IController
    {
        private DecorationRepository<IDecoration> decorRepositories;

        private ICollection<IAquarium> aquariums;

        private IAquarium aquarium;

        private IDecoration decoration;

        private IFish fish;

        public Controller()
        {
            decorRepositories = new DecorationRepository<IDecoration>();
            aquariums = new List<IAquarium>();
            
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {

            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else if (aquariumType != "SaltwaterAquarium" && aquariumType != "FreshwaterAquarium")
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }

            aquariums.Add(aquarium);

            return $"Successfully added {aquarium.GetType().Name}.";

        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "PLant")
            {
                decoration = new Plant();
            }
            else if (decorationType != "Ornament" && decorationType != "PLant")
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }
            decorRepositories.Add(decoration);

            return $"Successfully added {decoration.GetType().Name}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType != "FreshwaterFish" && fishType != "SaltwaterFish")
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            aquarium.AddFish(fish);
            return $"Successfully added {fish.GetType().Name} to {aquariumName}.";
        }

        public string CalculateValue(string aquariumName)
        {
            throw new NotImplementedException();
        }

        public string FeedFish(string aquariumName)
        {
            throw new NotImplementedException();
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}
