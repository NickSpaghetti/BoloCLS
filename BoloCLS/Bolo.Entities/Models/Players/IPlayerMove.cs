using Bolo.Entities.Models.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bolo.Entities.Models.Players
{
    public interface IPlayerMove
    {
        IPlayer Player { get; set; }
        ICard CardPlayed { get; set; }
        long NewScore { get; set; }
    }
}
