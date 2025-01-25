using UnityEngine;
using UnityEngine.Events;

namespace BubbleWarEpIV.Components
{
    public sealed class GameHead
        : MonoBehaviour
    {
        public UnityEvent<Collider> HitByBubble;

        private void OnTriggerEnter(Collider other)
        {
            HitByBubble?.Invoke(other);
            other.GetComponent<Bubble>().Pop();
        }
    }
}