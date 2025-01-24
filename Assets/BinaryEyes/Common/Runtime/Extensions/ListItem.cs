using System.Collections.Generic;
using UnityEngine;

namespace BinaryEyes.Core.Extensions
{
    public static class ListItem
    {
        public static T GetRandomItemOrNull<T>(this IReadOnlyList<T> collection)
            where T : class => collection.IsNullOrEmpty() ? null : collection.GetRandom();

        public static T GetRandom<T>(this IReadOnlyList<T> collection)
            => collection[Random.Range(0, collection.Count)];

        public static T GetLast<T>(this IReadOnlyList<T> collection)
            => collection[^1];

        public static T GetFirst<T>(this IReadOnlyList<T> collection)
            => collection[0];

        public static T GetItem<T>(this IReadOnlyList<T> collection, int index)
            => collection[index];

        public static IList<T> AddNotNull<T>(this IList<T> collection, T item)
        {
            if (item != null)
                collection.Add(item);

            return collection;
        }
    }
}