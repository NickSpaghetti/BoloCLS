using Bolo.Entities.Models.Abilities;
using Bolo.Entities.Models.Players;
using Bolo.Logic.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bolo.Logic.Abilities
{
    public class MirrorAbility : IAbility, ICardAbility
    {
        public GameManager GameManagerInstance => GameManager.Instance;

        /// <summary>
        /// Switches the position of your cards and your opponets
        /// </summary>
        /// <param name="playerMove"></param>
        public void Execute(IPlayerMove playerMove)
        {
            var otherPlayer = GameManagerInstance.GetPlayers().Where(p => p.PlayerId != playerMove.Player.PlayerId).FirstOrDefault();
            GameManagerInstance.SwapMoves(playerMove.Player, otherPlayer);
        }
    }
}
