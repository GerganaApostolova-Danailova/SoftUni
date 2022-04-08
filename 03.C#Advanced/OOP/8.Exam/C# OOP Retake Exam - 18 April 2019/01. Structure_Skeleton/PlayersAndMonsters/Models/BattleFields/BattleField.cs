using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        private ICardRepository cardRepository;

        public BattleField()
        {
            this.cardRepository = new CardRepository();
        }

        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            BeginnerBonus(attackPlayer);
            BeginnerBonus(enemyPlayer);

            BonusPoints(attackPlayer);
            BonusPoints(enemyPlayer);

            while (!enemyPlayer.IsDead && !attackPlayer.IsDead)
            {
                enemyPlayer.TakeDamage(attackPlayer.CardRepository.Cards.Sum(x => x.DamagePoints));

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyPlayer.CardRepository.Cards.Sum(x => x.DamagePoints));
            }
        }

        private void BonusPoints(IPlayer player)
        {
            var bonusPoints = player.CardRepository.Cards.Sum(x => x.HealthPoints);
            player.Health += bonusPoints;
        }

        private void BeginnerBonus(IPlayer player)
        {
            if (player.GetType().Name == "Beginner")
            {
                player.Health += 40;
                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
            //public class BattleField : IBattleField
            //{
            //    private const int DefaultDamagePointsForBeginner = 30;
            //    private const int DefaultHealthPointsForBeginner = 40;

            //public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
            //{
            //    if (attackPlayer.IsDead || enemyPlayer.IsDead)
            //    {
            //        throw new ArgumentException("Player is dead!");
            //    }

            //    CheckForBeginners(attackPlayer, enemyPlayer);

            //    attackPlayer.Health += attackPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);
            //    enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);

            //    while (true)
            //    {
            //        var attackPlayerTotalDamagePoints = attackPlayer.CardRepository.Cards.Sum(d => d.DamagePoints);
            //        enemyPlayer.TakeDamage(attackPlayerTotalDamagePoints);

            //        if (enemyPlayer.Health == 0)
            //        {
            //            break;
            //        }

            //        var enemyPlayerTotalDamagePoints = enemyPlayer.CardRepository.Cards.Sum(d => d.DamagePoints);
            //        attackPlayer.TakeDamage(enemyPlayerTotalDamagePoints);

            //        if (attackPlayer.Health == 0)
            //        {
            //            break;
            //        }
            //    }
            //}

            //private static void CheckForBeginners(IPlayer attackPlayer, IPlayer enemyPlayer)
            //{
            //    if (enemyPlayer.GetType() == typeof(Beginner))
            //    {
            //        enemyPlayer.Health += DefaultHealthPointsForBeginner;

            //        foreach (var card in enemyPlayer.CardRepository.Cards)
            //        {
            //            card.DamagePoints += DefaultDamagePointsForBeginner;
            //        }
            //    }

            //    if (attackPlayer.GetType() == typeof(Beginner))
            //    {
            //        attackPlayer.Health += DefaultHealthPointsForBeginner;

            //        foreach (var card in attackPlayer.CardRepository.Cards)
            //        {
            //            card.DamagePoints += DefaultDamagePointsForBeginner;
            //        }
            //    }
        }
    }
}
