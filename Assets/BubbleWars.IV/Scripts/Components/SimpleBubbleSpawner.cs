using System.Collections;
using BinaryEyes.Common.Data;
using UnityEngine;

namespace BubbleWarIV.Components
{
    public sealed class SimpleBubbleSpawner
        : MonoBehaviour
    {
        public Interval SpawnDelay;
        public Interval SpawnSize;
        public Interval SpawnDistance;
        public Range SpawnCount;
        public GameObject BubblePrefab;
        private void Awake() => StartCoroutine(SpawnBubbles());

        private IEnumerator SpawnBubbles()
        {
            var count = SpawnCount.GetRandom();
            for (var i = 0; i < count; i++)
            {
                yield return new WaitForSeconds(SpawnDelay.GetRandom());
                var bubble = Instantiate(BubblePrefab);
                bubble.transform.position = transform.position + transform.forward*SpawnDistance.GetRandom();
                bubble.transform.localScale = Vector3.one*SpawnSize.GetRandom();
            }
        }
    }
}