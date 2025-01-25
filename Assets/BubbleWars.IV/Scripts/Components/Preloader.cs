using System.Collections;
using BinaryEyes.Common.Extensions;
using UnityEngine;

namespace BubbleWarIV.Components
{
    public sealed class Preloader
        : MonoBehaviour
    {
        public Headset HeadsetPrefab;
        public string LocationScene;

        private void Awake()
            => StartCoroutine(PrepareGame());

        private IEnumerator PrepareGame()
        {
            yield return null;
            this.LogMessage("PreparingGame");

            var headset = Instantiate(HeadsetPrefab).SetName(HeadsetPrefab.name);
            DontDestroyOnLoad(headset.gameObject);
            
            headset.Fade.TurnTransparent();
        }
    }
}