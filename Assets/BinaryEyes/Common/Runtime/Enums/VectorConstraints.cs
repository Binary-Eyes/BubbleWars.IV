using System;

namespace BinaryEyes.Common.Enums
{
    /// <summary>
    /// Enumerates the different elements of a vector3 which can be constrained
    /// by the system's constraining components.
    /// </summary>
    [Flags]
    public enum VectorConstraints
    {
        None = 0,
        X = 1,
        Y = 1 << 1,
        Z = 1 << 2,
        Everything = X | Y | Z
    }
}
