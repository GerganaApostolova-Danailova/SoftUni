using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Beginner : Player
    {
        private const int begginerHealth = 50;

        public Beginner(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, begginerHealth)
        {
        }
    }
}
