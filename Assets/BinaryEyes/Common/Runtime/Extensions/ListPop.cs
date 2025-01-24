using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace BinaryEyes.Common.Extensions
{
    public static class ListPop
    {
        public static T PopRandom<T>(this List<T> list)
        {
            var index = Random.Range(0, list.Count);
            return list.Pop(index);
        }

        public static T PopLast<T>(this List<T> list)
        {
            return list.Pop(list.Count - 1);
        }

        public static T PopFirst<T>(this List<T> list)
        {
            return list.Pop(0);
        }

        public static T Pop<T>(this List<T> list, int index)
        {
            var item = list[index];
            list.RemoveAt(index);

            return item;
        }

        public static T PopByType<T>(this List<T> list, Type targetType)
        {
            if (list == null || list.Count == 0)
                return default;

            for (var i = list.Count - 1; i >= 0; i--)
            {
                var item = list[i];
                if (item.GetType() != targetType)
                    continue;

                list.RemoveAt(i);
                return item;
            }

            return default;
        }
    }
}
