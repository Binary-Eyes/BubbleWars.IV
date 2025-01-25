using BubbleWarsEp4.Components;
using UnityEngine;

namespace BubbleWarsEp4.Components
{
    public sealed class BubbleDrift
        : MonoBehaviour
    {
        public float UpSpeed = 1.0f;
        public float DriftSpeed = 0.5f;
        public Vector2 DriftRange = new(0.5f, 1f);
        public float PlayerBiasStrength = 10.0f;
        public float RotationSpeed = 30f;
        public float Lifetime = 10f;

        private Vector3 _driftDirection;
        private float _timeLeft;

        private void Start()
        {
            _driftDirection = new Vector3(
                Random.Range(-DriftRange.x, DriftRange.x),
                0,
                Random.Range(-DriftRange.y, DriftRange.y)
            );
        }

        private void Update()
        {
            var player = Headset.Instance.Camera.transform;
            var toCamera = (player.position - transform.position).normalized;
            var biasedDrift = Vector3.Lerp(_driftDirection, toCamera, PlayerBiasStrength);
            var movement = Vector3.up*UpSpeed*Time.deltaTime + biasedDrift*DriftSpeed*Time.deltaTime;
            transform.position += movement;
            transform.Rotate(Vector3.up, RotationSpeed*Time.deltaTime, Space.World);

            _timeLeft += Time.deltaTime;
            if (_timeLeft >= Lifetime)
                GetComponent<Bubble>().Pop();
        }
    }
}