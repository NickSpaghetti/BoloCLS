using System;
using System.Collections.Generic;
using System.Text;

namespace Bolo.Logic.Extentions
{
    public static class ListExtentions
    {
        public static void Shuffle<T>(this List<T> collection)
        {
            var random = new Random();
            int collectionLength = collection.Count;
            for (int i = 0; i < (collectionLength - 1); i++)
            {
                int randomValue = i + random.Next(collectionLength - i);
                T type = collection[randomValue];
                collection[randomValue] = collection[i];
                collection[i] = type;
            }

        }
    }
}
