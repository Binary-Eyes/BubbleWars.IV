using System;
using Newtonsoft.Json;
using UnityEngine;

namespace BinaryEyes.Common.Data
{
    /// <summary>
    /// The Float4 structure provides an easy to serialize form of the Vector4
    /// struct.
    /// </summary>
    [Serializable]
    public readonly struct Float4
    {
        public readonly float X;
        public readonly float Y;
        public readonly float Z;
        public readonly float W;

        public Vector4 ToVector4()
            => new(X, Y, Z, W);

        public Float4(Vector4 source)
        {
            X = source.x;
            Y = source.y;
            Z = source.z;
            W = source.w;
        }

        [JsonConstructor]
        public Float4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static implicit operator Vector4(Float4 source)
            => new(source.X, source.Y, source.Z, source.W);

        public static implicit operator Float4(Vector4 source)
            => new(source);
    }

    public static class Float4Extensions
    {
        public static Float4 ToFloat4(this Vector4 source) => new(source);
    }
}