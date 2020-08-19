using Bolo.Entities.Models.Abilities;
using Bolo.Entities.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bolo.Entities.Models.Cards
{
    public interface ICard
    {
        CardName Name { get; set; }

        ICardAbility Ability { get; set; }

        long Value { get; set; }
    }
}
