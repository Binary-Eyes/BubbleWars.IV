using BinaryEyes.Common.Data;
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
        public Interval RotationSpeed;
        public Interval Lifetime;

        private Vector3 _driftDirection;
        private Vector3 _rotationAxis;
        private float _rotationSpeed;
        private float _timeLeft;

        private void Start()
        {
            _driftDirection = new Vector3(
                Random.Range(-DriftRange.x, DriftRange.x),
                0,
                Random.Range(-DriftRange.y, DriftRange.y)
            );

            _timeLeft = Lifetime.GetRandom();
            _rotationSpeed = RotationSpeed.GetRandom();
            _rotationAxis = new Vector3(
                Random.Range(0.0f, 1.0f), 
                Random.Range(0.0f, 1.0f), 
                Random.Range(0.0f, 1.0f));
        }

        private void Update()
        {
            var player = Headset.Instance.Camera.transform;
            var target = player.position - Vector3.up*1.0f;

            var toCamera = (target - transform.position).normalized;
            var movement = Vector3.up*UpSpeed*Time.deltaTime + toCamera*DriftSpeed*Time.deltaTime;
            transform.position += movement;
            transform.Rotate(_rotationAxis, _rotationSpeed*Time.deltaTime, Space.World);

            _timeLeft -= Time.deltaTime;
            if (_timeLeft < 0.0f)
                GetComponent<Bubble>().Pop();
        }
    }
}