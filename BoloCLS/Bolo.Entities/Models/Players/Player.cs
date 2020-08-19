using Bolo.Entities.Models.Collections;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bolo.Entities.Models.Players
{
    public class Player : IPlayer
    {
        public Player(string displayName)
        {
            PlayerId = Guid.NewGuid();
            PlayerDisplayName = displayName;
            Hand = new Hand();
            GraveYard = new GraveYard();
        }

        public  Guid PlayerId { get; }
        public string PlayerDisplayName { get; set; }
        public Hand Hand { get; set; }
        public GraveYard GraveYard { get; set; }
    }
}
