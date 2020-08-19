using Bolo.Entities.Models.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bolo.Entities.Models.Collections
{
    public interface IDeck<T> where T : ICard
    {
        public IList<T> GetCards(int numberOfCards);

    }
}
