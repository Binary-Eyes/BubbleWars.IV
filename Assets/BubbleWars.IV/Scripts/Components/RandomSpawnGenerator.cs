using System.Collections;
using BinaryEyes.Common.Data;
using BinaryEyes.Common.Extensions;
using UnityEngine;

namespace BubbleWarEpIV.Components
{
    public sealed class RandomSpawnGenerator
        : MonoBehaviour
    {
        public float Delay;
        public Interval Radius;
        public Range SpawnerCount;
        public GameObject SpawnerPrefab;
        private void Awake() => StartCoroutine(GenerateSpawners());

        private IEnumerator GenerateSpawners()
        {
            yield return null;
            yield return new WaitForSeconds(Delay);

            var count = SpawnerCount.GetRandom();
            for (var i = 0; i < count; i++)
            {
                var hitInfo = GetSpawnPoint();
                if (hitInfo == null)
                    continue;

                var spawner = Instantiate(SpawnerPrefab).SetName($"Spawner ({i})");
                spawner.transform.position = hitInfo.Value.point;
                spawner.transform.forward = hitInfo.Value.normal;
            }
        }

        private RaycastHit? GetSpawnPoint()
        {
            var radius = Radius.GetRandom();
            var startPosition = Random.insideUnitCircle*radius;
            var spawnPosition = new Vector3(startPosition.x, 50.0f, startPosition.y);
            var ray = new Ray(spawnPosition, Vector3.down);
            var count = 0;
            while (count < 100)
            {
                count += 1;
                if (Physics.Raycast(ray, out var hitInfo))
                    return hitInfo;
            }

            Debug.LogWarning("failed to locate spawn point in location");
            return null;
        }
    }
}