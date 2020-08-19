using Bolo.Entities.Models.Abilities;
using Bolo.Entities.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bolo.Entities.Models.Cards
{
    public class GraveYardCard : IGraveYardCard, ICard
    {
        public GraveYardCard(CardName cardName, ICardAbility cardAbility, ICard cardRemovedBy, long cardValue)
        {
            Name = cardName;
            Ability = cardAbility;
            CardRemovedBy = cardRemovedBy;
            Value = cardValue;

        }


        public GraveYardCard(ICard card, ICard cardRemovedBy)
        {
            Name = card.Name;
            Ability = card.Ability;
            Value = card.Value;
            CardRemovedBy = cardRemovedBy;
            

        }

        public GraveYardCard(ICard card, IGraveYardCard cardRemovedBy)
        {
            Name = card.Name;
            Ability = card.Ability;
            Value = card.Value;
            CardRemovedBy = cardRemovedBy.CardRemovedBy;
        }

        public CardName Name { get; set; }
        public ICardAbility Ability { get; set; }
        public long Value { get; set; }
        public ICard CardRemovedBy { get; set; }
    }
}
