using Bolo.Logic.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bolo.Logic.Abilities
{
    public interface IAbility
    {
        GameManager GameManagerInstance { get; }
    }
}
