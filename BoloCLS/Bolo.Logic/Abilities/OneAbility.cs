using Bolo.Entities.Models.Abilities;
using Bolo.Entities.Models.Enums;
using Bolo.Entities.Models.Players;
using Bolo.Logic.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bolo.Logic.Abilities
{
    public class OneAbility : IAbility, ICardAbility
    {
        public GameManager GameManagerInstance => GameManager.Instance;

        /// <summary>
        /// brings any card removed by bolt from your grave yard back to the field
        /// </summary>
        /// <param name="playerMove"></param>
        public void Execute(IPlayerMove playerMove)
        {
            if (playerMove.Player.GraveYard.Cards.Any() && playerMove.Player.GraveYard.FindCardsRemovedBy(CardName.Bolt).Any()) 
            {
                var cardsRemovedByBolt = playerMove.Player.GraveYard.FindCardsRemovedBy(CardName.Bolt);
                Console.WriteLine($"The current Cards that can be be brought back are:");
                var index = 0;
                cardsRemovedByBolt.ToList().ForEach(c => { Console.WriteLine($"{c.Name}, Enter [{index}] to use"); index++; });
                var key = Console.ReadKey(true);
                var card = cardsRemovedByBolt[int.Parse(key.KeyChar.ToString())];
                playerMove.CardPlayed = card;
                playerMove.NewScore = card.Value;
                card.Ability.Execute(playerMove);

            }
        }
    }
}
