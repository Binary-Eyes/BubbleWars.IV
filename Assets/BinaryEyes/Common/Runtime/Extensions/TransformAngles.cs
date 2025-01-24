using UnityEngine;

namespace BinaryEyes.Common.Extensions
{
    public static class TransformAngles
    {
        public static Transform SetWorldAngleZ(this Transform source, float value)
        {
            var current = source.eulerAngles;
            current.z = value;
            source.eulerAngles = current;
            return source;
        }

        public static Transform SetWorldAngleY(this Transform source, float value)
        {
            var current = source.eulerAngles;
            current.y = value;
            source.eulerAngles = current;
            return source;
        }

        public static Transform SetWorldAngleX(this Transform source, float value)
        {
            var current = source.eulerAngles;
            current.x = value;
            source.eulerAngles = current;
            return source;
        }

        public static Transform SetLocalAngleZ(this Transform source, float value)
        {
            var current = source.localEulerAngles;
            current.z = value;
            source.localEulerAngles = current;
            return source;
        }

        public static Transform SetLocalAngleY(this Transform source, float value)
        {
            var current = source.localEulerAngles;
            current.y = value;
            source.localEulerAngles = current;
            return source;
        }

        public static Transform SetLocalAngleX(this Transform source, float value)
        {
            var current = source.localEulerAngles;
            current.x = value;
            source.localEulerAngles = current;
            return source;
        }

        public static Transform SetWorldAngles(this Transform source, Vector3 value)
        {
            source.eulerAngles = value;
            return source;
        }

        public static Transform SetLocalAngles(this Transform source, Vector3 value)
        {
            source.localEulerAngles = value;
            return source;
        }
    }
}