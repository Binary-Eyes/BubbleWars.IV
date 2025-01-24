using Newtonsoft.Json;
using System;
using UnityEngine;

namespace BinaryEyes.Common.Data
{
    /// <summary>
    /// The Float2 structure provides an easy to serialize form of the Vector2
    /// struct.
    /// </summary>
    [Serializable]
    public readonly struct Float2
    {
        public static readonly Float2 Zero = new(0.0f, 0.0f);
        public static readonly Float2 One = new(1.0f, 1.0f);

        public readonly float X;
        public readonly float Y;

        public Vector2 ToVector2()
            => new(X, Y);

        public Float2(Vector2 source)
        {
            X = source.x;
            Y = source.y;
        }

        [JsonConstructor]
        public Float2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static implicit operator Vector2(Float2 source)
            => new(source.X, source.Y);

        public static implicit operator Float2(Vector2 source)
            => new(source);
    }

    public static class Float2Extensions
    {
        public static Float2 ToFloat2(this Vector2 source) => new(source);
    }
}