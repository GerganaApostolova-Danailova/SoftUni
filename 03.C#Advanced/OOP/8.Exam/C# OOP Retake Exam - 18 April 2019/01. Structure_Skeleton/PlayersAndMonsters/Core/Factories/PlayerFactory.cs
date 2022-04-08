using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;

namespace PlayersAndMonsters.Core.Factories.Contracts
{
    public class PlayerFactory : IPlayerFactory
    {
        private CardRepository cardRepository;

        public PlayerFactory()
        {
            cardRepository = new CardRepository();
        }

        public IPlayer CreatePlayer(string type, string username)
        {
            IPlayer player = null;

            if (type == "Beginner")
            {
                player = new Beginner(cardRepository, username);
            }
            else if (type == "Advanced")
            {
                player = new Advanced(cardRepository, username);
            }

            return player;
        }
    }
}
