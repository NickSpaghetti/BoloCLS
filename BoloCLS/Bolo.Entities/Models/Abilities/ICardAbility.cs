using Bolo.Entities.Models.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bolo.Entities.Models.Abilities
{
    public interface ICardAbility
    { 
        public void Execute(IPlayerMove playerMove);
    }
}
