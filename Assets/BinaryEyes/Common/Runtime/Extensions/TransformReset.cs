using UnityEngine;

namespace BinaryEyes.Core.Extensions
{
    public static class TransformReset
    {
        public static Transform ResetWorld(this Transform source)
        {
            source.position = new Vector3(0.0f, 0.0f, 0.0f);
            source.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
            //source.lossyScale = new Vector3(1.0f, 1.0f, 1.0f); changing lossy-scale is not allowed by unity.
            return source;
        }

        public static Transform ResetLocal(this Transform source)
        {
            source.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            source.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
            source.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            return source;
        }
    }
}
