using BinaryEyes.Common.Enums;
using UnityEngine;

namespace BinaryEyes.Common.Components
{
    /// <summary>
    /// Constrains the owning transform to the rotation of a given source.
    /// </summary>
    [ExecuteInEditMode]
    public class ConstrainRotation
        : MonoBehaviour
    {
        public Transform Source;
        public VectorConstraints Target = VectorConstraints.Everything;

        public void Update()
        {
            if (Source == null)
                return;

            var current = transform.eulerAngles;
            var source = Source.eulerAngles;

            if (!Target.HasFlag(VectorConstraints.X))
                source.x = current.x;

            if (!Target.HasFlag(VectorConstraints.Y))
                source.y = current.y;

            if (!Target.HasFlag(VectorConstraints.Z))
                source.z = current.z;

            transform.eulerAngles = source;
        }
    }
}