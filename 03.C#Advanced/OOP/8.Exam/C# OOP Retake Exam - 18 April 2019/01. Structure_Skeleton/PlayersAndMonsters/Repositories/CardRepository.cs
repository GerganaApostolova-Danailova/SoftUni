using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly List<ICard> cards;

        public CardRepository()
        {
            this.cards = new List<ICard>();
        }

        public int Count 
            => cards.Count;

        public IReadOnlyCollection<ICard> Cards 
            => cards.AsReadOnly();

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null");
            }

            bool existingCard = cards
                .Any(p => p == card);

            if (existingCard)
            {
                throw new ArgumentException($"Card  {card.Name} already exists!");
            }

            cards.Add(card);
        }

        public ICard Find(string name)
        {
            return cards.FirstOrDefault(n=>n.Name == name);
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null");
            }
            if (cards.Any(p => p == card))
            {
                cards.Remove(card);
                return true;
            }

            return false;
        }
    }
}
