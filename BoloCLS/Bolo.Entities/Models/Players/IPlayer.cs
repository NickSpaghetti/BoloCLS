using Bolo.Entities.Models.Collections;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bolo.Entities.Models.Players
{
    public interface IPlayer
    {
        Guid PlayerId { get;  }
        string PlayerDisplayName { get; set; }
        Hand Hand { get; set; }
        GraveYard GraveYard { get; set; }

    }
}
