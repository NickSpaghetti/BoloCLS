using System;
using System.Collections.Generic;
using System.Text;

namespace Bolo.Entities.Models.Cards
{
    public interface IGraveYardCard
    {
        ICard CardRemovedBy { get; set; }
    }
}
