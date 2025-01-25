using UnityEngine;

namespace BinaryEyes.Common.Components
{
    public sealed class TransformScale
        : MonoBehaviour
    {
        public Space Space;
        public Vector3 Speed;

        private void Update()
            => transform.localScale += Speed*Time.deltaTime;
    }
}