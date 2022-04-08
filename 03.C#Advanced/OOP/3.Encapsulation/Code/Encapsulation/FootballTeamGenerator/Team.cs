using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private List<Player> players;
        private string name;

        private Team()
        {
            this.players = new List<Player>();
        }

        public Team(string name)
            :this()
        {
            Name = name;
            players = new List<Player>();
        }

        public IReadOnlyCollection<Player> Players =>
        players.AsReadOnly();


        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A name should not be empty.");
                }

                name = value;
            }
        }

        public int Rating 
            =>(int) (Math.Round(this.players.Average(p => p.CalculateStat), 0));

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            Player playerToRemove = players
                .FirstOrDefault(x => x.Name == name);

            if (playerToRemove == null)
            {
                throw new Exception($"Player {name} is not in {this.name} team.");
            }

            this.players.Remove(playerToRemove);
        }

        public override string ToString()
        {
            return $"{Name} - {Rating}";
        }
    }
}
