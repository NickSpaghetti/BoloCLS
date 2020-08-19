using Bolo.Entities.Models.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bolo.Entities.Models.Collections
{
    public class Hand : IBoloCollection<Card>
    {
        public Hand()
        {
            Cards = new List<Card>();
        }
        public IList<Card> Cards { get; }


        public void AddCards(IList<Card> cards)
        {
            foreach (var card in cards)
            {
                Cards.Add(card);
            }
        }

        public void RemoveCards(IList<Card> cards)
        {
            foreach (var card in cards)
            {
                RemoveCard(card);
            }
        }

        public void RemoveCard(Card card)
        {
            Cards.Remove(card);
        }

        public void ClearHand()
        {
            Cards.Clear();
        }
    }
}
