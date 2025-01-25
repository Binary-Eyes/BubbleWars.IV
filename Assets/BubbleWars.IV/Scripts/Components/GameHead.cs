using UnityEngine;
using UnityEngine.Events;

namespace BubbleWarsEp4.Components
{
    public sealed class GameHead
        : MonoBehaviour
    {
        public UnityEvent<Collider> HitByBubble;

        private void OnTriggerEnter(Collider other)
        {
            HitByBubble?.Invoke(other);
            other.GetComponent<Bubble>().Pop();
            Headset.Instance.LeftHand.Display.AddToBubbleBar(-0.02f);
        }
    }
}