using UnityEngine;

namespace BinaryEyes.Common.Components
{
    public sealed class TransformRotate
        : MonoBehaviour
    {
        public Space Space;
        public Vector3 Speed;

        private void Update()
        {
            var velocity = Speed*Time.deltaTime;
            transform.Rotate(velocity, Space);
        }
    }
}