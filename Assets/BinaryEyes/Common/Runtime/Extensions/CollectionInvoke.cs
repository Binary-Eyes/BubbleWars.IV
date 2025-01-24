using System;
using System.Collections.Generic;

namespace BinaryEyes.Common.Extensions
{
    public static class CollectionInvoke
    {
        public static IReadOnlyCollection<T> ForEachInvoke<T>(this IReadOnlyCollection<T> collection, Action<T> action)
        {
            if (action == null)
                return collection;

            if (collection == null)
                return null;

            foreach (var entry in collection)
                action.Invoke(entry);

            return collection;
        }

        public static IReadOnlyList<T> ForEachInvoke<T>(this IReadOnlyList<T> collection, Action<T> action)
        {
            if (action == null)
                return collection;

            if (collection == null)
                return null;

            for (var i = 0; i < collection.Count; i++)
                action.Invoke(collection[i]);

            return collection;
        }

        public static Dictionary<TKey, TValue> ForEachValueInvoke<TKey, TValue>(this Dictionary<TKey, TValue> collection, Action<TValue> action)
        {
            if (action == null)
                return collection;

            if (collection == null)
                return null;

            foreach (var entry in collection)
                action.Invoke(entry.Value);

            return collection;
        }

        public static Dictionary<TKey, TValue> ForEachKeyInvoke<TKey, TValue>(this Dictionary<TKey, TValue> collection, Action<TKey> action)
        {
            if (action == null)
                return collection;

            if (collection == null)
                return null;

            foreach (var entry in collection)
                action.Invoke(entry.Key);

            return collection;
        }

        public static List<T> ForEachInvoke<T>(this List<T> collection, Action<T> action)
        {
            if (action == null)
                return collection;

            if (collection == null)
                return null;

            for (var i = 0; i < collection.Count; i++)
                action.Invoke(collection[i]);

            return collection;
        }

        public static T[] ForEachInvoke<T>(this T[] collection, Action<T> action)
        {
            if (action == null)
                return collection;

            if (collection == null)
                return null;

            for (var i = 0; i < collection.Length; i++)
                action.Invoke(collection[i]);

            return collection;
        }
    }
}