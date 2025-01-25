using UnityEngine;

namespace BinaryEyes.Common.Components
{
    /// <summary>
    /// Forces the owning transform to 'look-at' a given target.
    /// </summary>
    [ExecuteInEditMode]
    public class LookAtTarget
        : MonoBehaviour
    {
        public Transform Target;

        private void Update()
        {
            if (Target != null)
                transform.LookAt(Target);
        }
    }
}
