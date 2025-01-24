using UnityEngine;

namespace BinaryEyes.Common.Extensions
{
    public static class GameObjectSet
    {
        public static GameObject SetParent(this GameObject source, Transform parent)
        {
            source.transform.SetParent(parent);
            return source;
        }

        public static GameObject SetHideFlags(this GameObject source, HideFlags flags)
        {
            source.hideFlags = flags;
            return source;
        }

        public static GameObject SetLayerRecursive(this GameObject source, string value)
        {
            if (source == null)
                return null;

            var layer = LayerMask.NameToLayer(value);
            var transforms = source.GetComponentsInChildren<Transform>(true);
            foreach (var transform in transforms)
                transform.gameObject.layer = layer;

            return source;
        }

        public static GameObject SetLayer(this GameObject source, string value)
        {
            if (source == null)
                return null;

            source.layer = LayerMask.NameToLayer(value);
            return source;
        }

        public static GameObject SetActiveState(this GameObject source, bool value)
        {
            if (source == null)
                return null;

            source.SetActive(value);
            return source;
        }

        public static GameObject SetName(this GameObject source, string value)
        {
            if (source == null)
                return null;

            source.name = value;
            return source;
        }
    }
}
