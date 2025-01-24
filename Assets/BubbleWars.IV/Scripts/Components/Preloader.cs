using System.Collections;
using BinaryEyes.Common.Extensions;
using UnityEngine;

namespace BubbleWarIV.Components
{
    public sealed class Preloader
        : MonoBehaviour
    {
        public string LocationScene;

        private void Awake()
            => StartCoroutine(PrepareGame());

        private IEnumerator PrepareGame()
        {
            yield return null;
            this.LogMessage("PreparingGame");
        }
    }
}