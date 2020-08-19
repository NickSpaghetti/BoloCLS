using Bolo.Entities.Models.Abilities;
using Bolo.Entities.Models.Players;
using Bolo.Logic.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bolo.Logic.Abilities
{
    public class BoloAbility : IAbility, ICardAbility
    {
        public GameManager GameManagerInstance { get => GameManager.Instance; }

        /// <summary>
        /// All number cards exepct for One have no ability.  
        /// </summary>
        /// <param name=""></param>
        public void Execute(IPlayerMove playerMove)
        {

        }
    }
}
