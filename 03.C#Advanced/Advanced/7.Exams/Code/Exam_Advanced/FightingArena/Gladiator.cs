using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Gladiator
    {
        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            Name = name;
            Stat = stat;
            Weapon = weapon;
        }

        public int GetTotalPower()
        {
            return Stat.Agility + Stat.Flexibility + Stat.Strength + Stat.Skills + Stat.Intelligence
                + Weapon.Size + Weapon.Solidity + Weapon.Sharpness;
        }

        public int GetWeaponPower()
        {
            return Weapon.Size + Weapon.Solidity + Weapon.Sharpness;
        }

        public int GetStatPower()
        {
            return Stat.Agility + Stat.Flexibility + Stat.Strength + Stat.Skills + Stat.Intelligence;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"[{this.Name}] - [{this.GetTotalPower()}]");
            sb.AppendLine($"  Weapon Power: {this.GetWeaponPower()}");
            sb.AppendLine($"  Stat Power: {this.GetStatPower()}]");

            return sb.ToString();
        }

        public string Name { get; set; }
        public Stat Stat { get; set; }
        public Weapon Weapon { get; set; }
    }
}
