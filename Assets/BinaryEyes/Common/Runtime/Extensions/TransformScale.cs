using UnityEngine;

namespace BinaryEyes.Common.Extensions
{
    public static class TransformScale
    {
        public static Transform SetLocalScaleZ(this Transform source, float value)
        {
            var current = source.localScale;
            current.z = value;
            source.localScale = current;
            return source;
        }

        public static Transform SetLocalScaleY(this Transform source, float value)
        {
            var current = source.localScale;
            current.y = value;
            source.localScale = current;
            return source;
        }

        public static Transform SetLocalScaleX(this Transform source, float value)
        {
            var current = source.localScale;
            current.x = value;
            source.localScale = current;
            return source;
        }

        public static Transform SetLocalScale(this Transform source, Vector3 value)
        {
            source.localScale = value;
            return source;
        }
    }
}