using UnityEngine;

namespace BinaryEyes.Common.Extensions
{
    public static class ComponentSet
    {
        public static T SetParent<T>(this T source, Transform parent)
            where T : Component
        {
            source.transform.SetParent(parent);
            return source;
        }

        public static T SetHideFlags<T>(this T source, HideFlags flags)
            where T : Component
        {
            source.hideFlags = flags;
            return source;
        }

        public static T SetLayerRecursive<T>(this T source, string value)
            where T : Component
        {
            if (!source)
                return null;

            var layer = LayerMask.NameToLayer(value);
            var transforms = source.GetComponentsInChildren<Transform>(true);
            foreach (var transform in transforms)
                transform.gameObject.layer = layer;

            return source;
        }

        public static T SetLayer<T>(this T source, string value)
            where T : Component
        {
            if (!source)
                return null;

            source.gameObject.layer = LayerMask.NameToLayer(value);
            return source;
        }

        public static T SetActiveState<T>(this T source, bool value)
            where T : Component
        {
            if (!source)
                return null;

            source.gameObject.SetActive(value);
            return source;
        }

        public static T SetName<T>(this T source, string value)
            where T : Component
        {
            if (!source)
                return null;

            source.name = value;
            return source;
        }
    }
}