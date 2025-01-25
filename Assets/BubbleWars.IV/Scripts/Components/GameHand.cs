using BinaryEyes.Common.Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace BubbleWarsEp4.Components
{
    public sealed class GameHand
        : MonoBehaviour
    {
        public string FingerTipLayer = "FingerTips";
        public HandDisplay Display;
        public FingerInteractionPoint[] InteractionPoints;
        public UnityEvent BubblePopped;

        private void OnTriggerEnter(Collider other)
        {
            var bubble = other.GetComponentInParent<Bubble>();
            if (!bubble)
                return;

            if (!bubble.Pop())
                return;

            if (Display)
                Display.AddToBubbleBar(0.1f);

            SoundManager.Instance.PlayBubblePop(other.transform);
            BubblePopped.Invoke();
        }

        private void Start()
        {
            InteractionPoints = GetComponentsInChildren<FingerInteractionPoint>(true);
            foreach (var interactionPoint in InteractionPoints)
                interactionPoint.SetLayer(FingerTipLayer);
        }
    }
}