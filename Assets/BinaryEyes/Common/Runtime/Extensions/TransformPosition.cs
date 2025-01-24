using UnityEngine;

namespace BinaryEyes.Common.Extensions
{
    public static class TransformPosition
    {
        public static Transform SetWorldPositionZ(this Transform source, float value)
        {
            var current = source.position;
            current.z = value;
            source.position = current;
            return source;
        }

        public static Transform SetWorldPositionY(this Transform source, float value)
        {
            var current = source.position;
            current.y = value;
            source.position = current;
            return source;
        }

        public static Transform SetWorldPositionX(this Transform source, float value)
        {
            var current = source.position;
            current.x = value;
            source.position = current;
            return source;
        }

        public static Transform SetLocalPositionZ(this Transform source, float value)
        {
            var current = source.localPosition;
            current.z = value;
            source.localPosition = current;
            return source;
        }

        public static Transform SetLocalPositionY(this Transform source, float value)
        {
            var current = source.localPosition;
            current.y = value;
            source.localPosition = current;
            return source;
        }

        public static Transform SetLocalPositionX(this Transform source, float value)
        {
            var current = source.localPosition;
            current.x = value;
            source.localPosition = current;
            return source;
        }

        public static Transform SetWorldPosition(this Transform source, Vector3 value)
        {
            source.position = value;
            return source;
        }

        public static Transform SetLocalPosition(this Transform source, Vector3 value)
        {
            source.localPosition = value;
            return source;
        }
    }
}