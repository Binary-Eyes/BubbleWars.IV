using System.Collections.Generic;
using BinaryEyes.Common.Extensions;
using UnityEngine;

namespace BubbleWarEpIV.Components
{
    public sealed class Bubble
        : MonoBehaviour
    {
        public static readonly List<Bubble> Bubbles = new();
        public bool IsPopped { get; private set; }

        public void Pop()
        {
            if (IsPopped)
                return;

            this.LogMessage("Popping");
            IsPopped = true;
            Destroy(gameObject);
        }

        private void Awake()
            => Bubbles.Add(this);

        private void OnDestroy()
            => Bubbles.Remove(this);
    }
}