using Bolo.Entities.Models.Abilities;
using Bolo.Entities.Models.Cards;
using Bolo.Entities.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bolo.Entities.Models.Collections
{
    public class GraveYard : IBoloCollection<GraveYardCard>
    {
        public GraveYard()
        {
            Cards = new List<GraveYardCard>();
        }
        public IList<GraveYardCard> Cards { get; }

        public void AddCards(IList<GraveYardCard> cards)
        {
            foreach (var card in cards)
            {
                Cards.Add(card);
            }
        }

        public void RemoveCards(IList<GraveYardCard> cards)
        {
            foreach (var card in cards)
            {
                RemoveCard(card);
            }
        }

        public void RemoveCard(GraveYardCard card)
        {
            Cards.Remove(card);
        }

        public IList<GraveYardCard> FindCardsRemovedBy(CardName cardName)
        {
            return Cards.Where(c => c.CardRemovedBy.Name == cardName).ToList();
        }

    }
}
