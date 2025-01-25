using UnityEngine;
using UnityEngine.Events;

namespace BubbleWarEp4.Components
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