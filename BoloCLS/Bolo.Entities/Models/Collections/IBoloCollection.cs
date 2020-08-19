using Bolo.Entities.Models.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bolo.Entities.Models.Collections
{
    public interface IBoloCollection<T> where T : ICard
    {
        IList<T> Cards { get; }

        void AddCards(IList<T> cards);

        void RemoveCards(IList<T> cards);

        void RemoveCard(T card);
    }
}
