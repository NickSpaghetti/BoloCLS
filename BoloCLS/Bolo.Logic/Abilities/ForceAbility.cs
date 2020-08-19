using Bolo.Entities.Models.Abilities;
using Bolo.Entities.Models.Players;
using Bolo.Logic.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bolo.Logic.Abilities
{
    public class ForceAbility : IAbility, ICardAbility
    {
        public GameManager GameManagerInstance { get => GameManager.Instance; }

        /// <summary>
        /// Double your Value
        /// </summary>
        /// <param name="playerMove"></param>
        public void Execute(IPlayerMove playerMove)
        {
            var doubledScore = GameManagerInstance.GetPlayerScore(playerMove.Player).Value * 2;
            playerMove.NewScore = doubledScore;
        }
    }
}
