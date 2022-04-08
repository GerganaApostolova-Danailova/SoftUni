using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        private const int damagePointTrapCard = 120;
        private const int healthPointTrapCard = 5;

        public TrapCard(string name) 
            : base(name, damagePointTrapCard, healthPointTrapCard)
        {
        }
    }
}
