using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models.Players
{
    public abstract class Player : ICivilPlayer
    {
        private string name;
        private int livePoints;
        private IRepository<IGun> gunRepository;

        protected Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            this.GunRepository = new GunRepository();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException
                        ("Player's name cannot be null or a whitespace!");
                }

                name = value;
            }
        }

        public bool IsAlive => LifePoints > 0;

        public IRepository<IGun> GunRepository { get; set; }

        public int LifePoints
        {
            get => livePoints;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException
                        ("Player life points cannot be below zero!");
                }

                livePoints = value;
            }
        }

        public void TakeLifePoints(int points)
        {
            this.livePoints -= points;

            if (livePoints < 0)
            {
                this.livePoints = 0;
            }
        }
    }
}
