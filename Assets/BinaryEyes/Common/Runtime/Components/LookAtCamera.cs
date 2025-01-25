using UnityEngine;

namespace BinaryEyes.Common.Components
{
    public class LookAtCamera
        : MonoBehaviour
    {
        public bool TargetMainCamera = true;
        public Camera Target;

        private void LateUpdate()
        {
            Target = FindTarget();
            if (Target == null)
                return;

            transform.LookAt(Target.transform);
        }

        private Camera FindTarget()
        {
            if (Target == null && TargetMainCamera)
                return Camera.main;

            return Target;
        }
    }
}
