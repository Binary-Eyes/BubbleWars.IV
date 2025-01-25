using System.Collections.Generic;
using BinaryEyes.Common.Extensions;
using UnityEngine;

namespace BubbleWarsEp4.Components
{
    public sealed class Bubble
        : MonoBehaviour
    {
        public static readonly List<Bubble> Bubbles = new();
        public bool IsPopped { get; private set; }

        public bool Pop()
        {
            if (IsPopped)
                return false;

            this.LogMessage("Popping");
            IsPopped = true;
            Destroy(gameObject);
            return true;
        }

        private void Awake()
            => Bubbles.Add(this);

        private void OnDestroy()
            => Bubbles.Remove(this);
    }
}