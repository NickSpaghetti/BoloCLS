using Bolo.Entities.Models.Abilities;
using Bolo.Entities.Models.Enums;
using Bolo.Logic.Abilities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Bolo.Logic.Extentions
{
    public static class CardNameExtentions
    {
        public static long GetInitalCardValue(this CardName cardName)
        {
            return cardName switch
            {
                _ when
                cardName == CardName.One || cardName == CardName.Bolt || cardName == CardName.Blast || cardName == CardName.Force || cardName == CardName.Mirror  => 1 ,
                CardName.Two => 2,
                CardName.Three => 3,
                CardName.Four => 4,
                CardName.Five => 5,
                CardName.Six => 6,
                CardName.Seven => 7,
                _ => 0
            };
        }


        public static ICardAbility GetCardAbility(this CardName cardName)
        {
            var reflectionNameSpace = typeof(IAbility).Namespace;
            var typeToLoad = Type.GetType($"{reflectionNameSpace}.{cardName}Ability");
            ICardAbility cardAbility;
            if (typeToLoad == null)
            {
                cardAbility = new BoloAbility();
            }
            else
            {
                cardAbility = (ICardAbility)Activator.CreateInstance(typeToLoad);
            }
            return cardAbility;
        }
    }
}
