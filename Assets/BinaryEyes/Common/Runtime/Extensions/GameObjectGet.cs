using System.Collections.Generic;
using UnityEngine;

namespace BinaryEyes.Common.Extensions
{
    public static class GameObjectGet
    {
        public static string GetScenePath(this GameObject source)
        {
            if (source == null)
                return string.Empty;

            var elements = new List<string> { source.name };
            var parent = source.transform.parent;
            while (parent != null)
            {
                elements.Insert(0, parent.name);
                parent = parent.parent;
            }

            return string.Join("/", elements);
        }
    }
}