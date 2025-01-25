using UnityEngine;

namespace BinaryEyes.Common.Components
{
    public sealed class TransformMove
        : MonoBehaviour
    {
        public Space Space;
        public Vector3 Speed;

        private void Update()
        {
            var velocity = Speed*Time.deltaTime;
            transform.Translate(velocity, Space);
        }
    }
}