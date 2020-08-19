using Bolo.Entities.Models.Abilities;
using Bolo.Entities.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bolo.Entities.Models.Cards
{
    public class Card : ICard
    {
        public Card(CardName cardName, ICardAbility cardAbility, long cardValue)
        {
            Name = cardName;
            Ability = cardAbility;
            Value = cardValue;

        }
        public CardName Name { get; set; }
        public ICardAbility Ability { get; set; }
        public long Value { get; set; }
    }
}
