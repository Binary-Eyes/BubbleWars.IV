using BinaryEyes.Common.Extensions;
using UnityEngine;

namespace BubbleWarEpIV.Components
{
    public sealed class GameHand
        : MonoBehaviour
    {
        public string FingerTipLayer = "FingerTips";
        public FingerInteractionPoint[] InteractionPoints;

        private void OnTriggerEnter(Collider other)
        {
            var bubble = other.GetComponentInParent<Bubble>();
            if (bubble)
                bubble.Pop();
        }

        private void Start()
        {
            InteractionPoints = GetComponentsInChildren<FingerInteractionPoint>(true);
            foreach (var interactionPoint in InteractionPoints)
                interactionPoint.SetLayer(FingerTipLayer);
        }
    }
}