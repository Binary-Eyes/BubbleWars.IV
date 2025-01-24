using System;

namespace BinaryEyes.Common.Enums
{
 
    /// <summary>
    /// Enumerates the different transform elements that can be constrained by
    /// the constrain-transform component.
    /// </summary>
    [Flags]
    public enum TransformConstraints
    {
        None = 0,
        Position = 1 << 0,
        Rotation = 1 << 1,
        Scale = 1 << 2,
        Everything = Position | Rotation | Scale
    }
}
