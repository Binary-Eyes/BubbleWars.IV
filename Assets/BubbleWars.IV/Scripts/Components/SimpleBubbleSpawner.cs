using System.Collections;
using BinaryEyes.Common.Data;
using UnityEngine;

namespace BubbleWarEp4.Components
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
            var initialDelay = new Interval(1.0f, 3.0f);
            yield return new WaitForSeconds(initialDelay.GetRandom());

            var count = SpawnCount.GetRandom();
            for (var i = 0; i < count; i++)
            {
                var bubble = Instantiate(BubblePrefab);
                bubble.transform.position = transform.position + transform.forward*SpawnDistance.GetRandom();
                bubble.transform.localScale = Vector3.one*SpawnSize.GetRandom();
                yield return new WaitForSeconds(SpawnDelay.GetRandom());
            }
        }
    }
}