using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Players
            => this.players.AsReadOnly();

        public int Count => players.Count;


        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            bool existingPlayer = players
                .Any(p => p.Username == player.Username);

            if (existingPlayer)
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            players.Add(player);
        }

        public IPlayer Find(string username)
        {
            var player = players.FirstOrDefault(p=> p.Username == username);

            return player;
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            if (players.Any(p => p == player))
            {
                players.Remove(player);
                return true;
            }

            return false;

            //var isRemove = this.players.Remove(player);

            //return isRemove;
        }
    }
}
