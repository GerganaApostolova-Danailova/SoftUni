using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AquaShop.Models
{
    public class Aquarium : IAquarium
    {
        private string name;
        private int capacity;

        private List<IDecoration> decorations;
        private List<IFish> fishes;

        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fishes = new List<IFish>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }

                name = value;
            }
        }
        // set the fishes.count -> the capasity

        public int Capacity { get; private set; }

        public int Comfort => decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations { get; }

        public ICollection<IFish> Fish { get; }

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.capacity > 0)
            {
                this.fishes.Add(fish);
            }
            else
            {
                throw new InvalidOperationException("Not enough capacity.");
            }
        }

        public void Feed()
        {
            foreach (var fish in fishes)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            if (fishes.Count == 0)
            {
                sb.AppendLine("None");
            }
            else
            {
                //sb.AppendLine($"{this.GetType().Name} ({aquariumType}):);
            }

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return fishes.Remove(fish);
        }
    }
}
