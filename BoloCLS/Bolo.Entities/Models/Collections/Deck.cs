using Bolo.Entities.Models.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Bolo.Entities.Models.Collections
{
    public class Deck : IDeck<Card>, IBoloCollection<Card>
    {
        public Deck()
        {
            Cards = new List<Card>();
        }
        public IList<Card> Cards { get; set; }

        public void AddCards(IList<Card> cards)
        {
            foreach (var card in cards)
            {
                Cards.Add(card);
            }
        }

        public IList<Card> GetCards(int numberOfCards)
        {
            var cardsToDeal = new List<Card>();
            if(Cards.Any())
            {
                if(Cards.Count < numberOfCards)
                {
                    cardsToDeal = Cards.Select(c => c).ToList();
                    Cards = new List<Card>();
                }
                else
                {
                    cardsToDeal = Cards.Take(numberOfCards).ToList();
                }

                RemoveCards(cardsToDeal);
            }

            return cardsToDeal;
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
    }
}
