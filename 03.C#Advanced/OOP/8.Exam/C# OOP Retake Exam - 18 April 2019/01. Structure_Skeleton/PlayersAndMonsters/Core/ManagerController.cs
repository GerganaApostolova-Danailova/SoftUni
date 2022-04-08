namespace PlayersAndMonsters.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Contracts;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;
    using System.Text;

    public class ManagerController : IManagerController
    {
        private ICardRepository cardRepository;
        private IPlayerRepository playerRepository;
        private PlayerFactory playerFactory;
        private CardFactory cardFactory;
        private BattleField battleField;

        public ManagerController()
        {
            this.cardRepository = new CardRepository();
            this.playerRepository = new PlayerRepository();
            this.playerFactory = new PlayerFactory();
            this.cardFactory = new CardFactory();
            this.battleField = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            var player = playerFactory.CreatePlayer(type, username);
            playerRepository.Add(player);

            return $"Successfully added player of type {type} with username: {username}";
        }

        public string AddCard(string type, string name)
        {
            var card = cardFactory.CreateCard(type, name);
            cardRepository.Add(card);

            return $"Successfully added card of type {type}Card with name: {name}";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = playerRepository.Players.FirstOrDefault(p => p.Username == username);
            var card = cardRepository.Cards.FirstOrDefault(c => c.Name == cardName);

            player.CardRepository.Add(card);

            return $"Successfully added card: {cardName} to user: {username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attackerPlayer = playerRepository.Players.FirstOrDefault(a => a.Username == attackUser);
            var enimyPLayer = playerRepository.Players.FirstOrDefault(e => e.Username == enemyUser);

            battleField.Fight(attackerPlayer, enimyPLayer);

            return $"Attack user health {attackerPlayer.Health} - Enemy user health {enimyPLayer.Health}";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in playerRepository.Players)
            {
                sb.AppendLine($"Username: {player.Username} - Health: {player.Health} – Cards {player.CardRepository.Count}");

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                }

                sb.AppendLine("###");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
