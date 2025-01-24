using System.Collections.Generic;
using UnityEngine;

namespace BinaryEyes.Common.Extensions
{
    public static class CoroutineControls
    {
        public static void CancelCoroutines(this MonoBehaviour source, List<Coroutine> coroutines)
        {
            foreach (var coroutine in coroutines)
                source.CancelCoroutine(coroutine);

            coroutines.Clear();
        }

        public static Coroutine CancelCoroutine(this MonoBehaviour source, Coroutine coroutine)
        {
            if (coroutine != null)
                source.StopCoroutine(coroutine);

            return null;
        }
    }
}