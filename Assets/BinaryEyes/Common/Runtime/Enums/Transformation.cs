using BinaryEyes.Common.Enums;
using UnityEngine;

namespace BinaryEyes.Common.Data
{
    /// <summary>
    /// The Transformation structure provides information regarding a particular
    /// transform node at a given point in time.
    /// </summary>
    public readonly struct Transformation
    {
        public readonly ObjectSpace Space;
        public readonly Vector3 Position;
        public readonly Quaternion Rotation;
        public readonly Vector3 Scale;

        public static Transformation Local(Vector3 position, Quaternion rotation, Vector3 scale)
            => new(ObjectSpace.Local, position, rotation, scale);

        public static Transformation World(Vector3 position, Quaternion rotation, Vector3 scale)
            => new(ObjectSpace.World, position, rotation, scale);

        public Transformation(ObjectSpace space, Vector3 position, Quaternion rotation, Vector3 scale)
        {
            Space = space;
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }
    }
}