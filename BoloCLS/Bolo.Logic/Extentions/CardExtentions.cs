using Bolo.Entities.Models.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bolo.Logic.Extentions
{
    public static class CardExtentions
    {
        public static Card ToCard(this ICard card)
        {
            return new Card(card.Name, card.Ability, card.Value);
        }

        public static IEnumerable<Card> ToCards(this IEnumerable<ICard> cards)
        {
            return cards.Select(c => c.ToCard()).ToList();
        }

    }
}
