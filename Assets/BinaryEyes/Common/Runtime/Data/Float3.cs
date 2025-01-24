using Newtonsoft.Json;
using System;
using UnityEngine;

namespace BinaryEyes.Common.Data
{
    /// <summary>
    /// The Float3 structure provides an easy to serialize form of the Vector3
    /// struct.
    /// </summary>
    [Serializable]
    public readonly struct Float3
    {
        public readonly float X;
        public readonly float Y;
        public readonly float Z;

        public Vector3 ToVector3()
            => new(X, Y, Z);

        public Float3(Vector3 source)
        {
            X = source.x;
            Y = source.y;
            Z = source.z;
        }

        [JsonConstructor]
        public Float3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static implicit operator Vector3(Float3 source)
            => new(source.X, source.Y, source.Z);

        public static implicit operator Float3(Vector3 source)
            => new(source);
    }

    public static class Float3Extensions
    {
        public static Float3 ToFloat3(this Vector3 source) => new(source);
    }
}