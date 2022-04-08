using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        private bool defenseMode = false;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, 100)
        {
            ToggleDefenseMode();
        }

        public bool DefenseMode => defenseMode;

        public void ToggleDefenseMode()
        {
            if (defenseMode)
            {
                defenseMode = false;
            }
            else
            {
                defenseMode = true;
            }

            if (defenseMode)
            {
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
            else
            {
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
        }

        public override string ToString()
        {
            if (defenseMode)
            {
                return base.ToString() + Environment.NewLine + " *Defense: ON";
            }

            return base.ToString() + Environment.NewLine + " *Defense: OOF";
        }
    }
}
