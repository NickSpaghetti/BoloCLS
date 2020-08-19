using Bolo.Entities.Models.Abilities;
using Bolo.Entities.Models.Players;
using Bolo.Logic.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bolo.Logic.Abilities
{
    public class BlastAbility : IAbility, ICardAbility
    {
        public GameManager GameManagerInstance { get => GameManager.Instance; }

        /// <summary>
        /// Allows Player to remove a card from the players hand
        /// </summary>
        /// <param name="playerMove"></param>
        public void Execute(IPlayerMove playerMove)
        {
            var otherPlayer = GameManagerInstance.GetPlayers().Where(p => p.PlayerId != playerMove.Player.PlayerId).FirstOrDefault();
            Console.WriteLine($"Select a number {0} though {otherPlayer.Hand.Cards.Count - 1} to remove that card from your oponents hand:");
            var key = Console.ReadKey(true);
            var card = otherPlayer.Hand.Cards[int.Parse(key.KeyChar.ToString())];
            otherPlayer.Hand.RemoveCard(card);
        }
    }
}
