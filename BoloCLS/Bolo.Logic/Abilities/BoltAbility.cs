using Bolo.Entities.Models.Abilities;
using Bolo.Entities.Models.Cards;
using Bolo.Entities.Models.Players;
using Bolo.Logic.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bolo.Logic.Abilities
{
    public class BoltAbility : IAbility, ICardAbility
    {
        public GameManager GameManagerInstance { get => GameManager.Instance; }

        /// <summary>
        /// Removes The last card played by your opponent
        /// </summary>
        /// <param name="playerMove"></param>
        public void Execute(IPlayerMove playerMove)
        {
            var otherPlayer = GameManagerInstance.GetPlayers().Where(p => p.PlayerId != playerMove.Player.PlayerId).FirstOrDefault();
            var otherPlayerMoves = GameManagerInstance.GetPlayerMoves(otherPlayer);
            var otherPlayerLastMove = otherPlayerMoves.LastOrDefault();
            var newValue = GameManagerInstance.GetPlayerScore(otherPlayer).Value - otherPlayerLastMove.NewScore;
            otherPlayer.GraveYard.AddCards(new List<GraveYardCard>() { new GraveYardCard(playerMove.CardPlayed, otherPlayerLastMove.CardPlayed) });
            GameManagerInstance.UpdatePlayerScore(otherPlayer, newValue);
        }
    }
}
