using System.Collections.Generic;

namespace BinaryEyes.Common.Extensions
{
    public static class ListQuery
    {
        public static bool IsNullOrEmpty<T>(this IReadOnlyList<T> collection)
            => collection == null || collection.Count == 0;

        public static bool IsEmpty<T>(this IReadOnlyList<T> collection)
            => collection.Count == 0;

        public static bool IsNull<T>(this IReadOnlyList<T> collection)
            => collection == null;
    }
}