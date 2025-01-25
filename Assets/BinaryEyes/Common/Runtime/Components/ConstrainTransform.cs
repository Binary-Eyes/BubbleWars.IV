using BinaryEyes.Common.Enums;
using UnityEngine;

namespace BinaryEyes.Common.Components
{
    /// <summary>
    /// Constrains the owning transform to a particular data source.
    /// </summary>
    [ExecuteInEditMode]
    public class ConstrainTransform
        : MonoBehaviour
    {
        public Transform Source;
        public TransformConstraints Target = TransformConstraints.Everything;

        public ConstrainTransform SetType(TransformConstraints value)
        {
            Target = value;
            return this;
        }

        public ConstrainTransform SetTarget(Transform target)
        {
            Source = target;
            return this;
        }

        public void Update()
        {
            if (Source == null)
                return;

            if (Target.HasFlag(TransformConstraints.Position))
                transform.position = Source.position;

            if (Target.HasFlag(TransformConstraints.Rotation))
                transform.rotation = Source.rotation;

            if (Target.HasFlag(TransformConstraints.Scale))
                transform.localScale = Source.localScale;
        }
    }
}
