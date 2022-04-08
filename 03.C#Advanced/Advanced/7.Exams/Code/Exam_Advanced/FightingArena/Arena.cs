using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FightingArena
{
    class Arena
    {
        public string Name { get; set; }

        private List<Gladiator> gladiators = new List<Gladiator>();

        public Arena(string name)
        {
            this.Name = name;
            // this.gladiators = new List<Gladiator>();
        }

        public int Count => this.gladiators.Count;

        public void Add(Gladiator gladiator)
        {
            this.gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            Gladiator gladiatorToRemove = gladiators.FirstOrDefault(x => x.Name == name);
            gladiators.Remove(gladiatorToRemove);
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            int maxStatPower = gladiators.Max(x => x.GetStatPower());

            return gladiators.FirstOrDefault(x => x.GetStatPower() == maxStatPower);
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            int maxWeaponPower = gladiators.Max(x => x.GetWeaponPower());

            return gladiators.FirstOrDefault(x => x.GetWeaponPower() == maxWeaponPower);
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            int maxTotalPower = gladiators.Max(x => x.GetTotalPower());

            return gladiators.FirstOrDefault(x => x.GetTotalPower() == maxTotalPower);
        }

        public override string ToString()
        {
            return $"[{this.Name}] - [{this.gladiators.Count}] gladiators are participating.";
        }
    }
}
