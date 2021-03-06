using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private bool agressiveMode = false;

        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, 200)
        {
            ToggleAggressiveMode();
        }
        public bool AggressiveMode => agressiveMode;

        public void ToggleAggressiveMode()
        {
            if (agressiveMode)
            {
                agressiveMode = false;
            }
            else
            {
                agressiveMode = true;
            }

            if (agressiveMode)
            {
                AttackPoints += 50;
                DefensePoints -= 25;
            }
            else
            {
                AttackPoints -= 50;
                DefensePoints += 25;
            }
        }

        public override string ToString()
        {
            if (agressiveMode)
            {
                return base.ToString() + Environment.NewLine + " *Aggressive: ON";
            }

            return base.ToString() + Environment.NewLine + " *Aggressive: OOF";
        }

    }
}
