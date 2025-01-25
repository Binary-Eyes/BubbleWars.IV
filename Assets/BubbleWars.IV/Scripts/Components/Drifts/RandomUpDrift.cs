using UnityEngine;

namespace BubbleWarsEp4.Components
{
    public sealed class BubbleDrift
        : MonoBehaviour
    {
        [Header("Movement Settings")]
        public float upwardSpeed = 1f;                // Speed at which the bubble rises
        public float driftSpeed = 0.5f;               // Speed of horizontal drift
        public Vector2 driftRange = new(0.5f, 1f); // Range of random drift variation
        public float cameraBiasStrength = 0.2f;       // Strength of the drift bias towards the camera

        [Header("Rotation Settings")]
        public float rotationSpeed = 30f;            // Rotation speed for added realism

        [Header("Lifetime Settings")]
        public float lifetime = 10f;                 // Time (in seconds) before the bubble pops

        private Vector3 driftDirection;              // Random direction for horizontal drift
        private float elapsedTime;                   // Timer to track bubble lifetime
        private Transform cameraTransform;           // Reference to the main camera's transform

        private void Start()
        {
            // Generate a random initial drift direction
            driftDirection = new Vector3(
                Random.Range(-driftRange.x, driftRange.x),
                0,
                Random.Range(-driftRange.y, driftRange.y)
            );

            // Find the main camera in the scene
            cameraTransform = Camera.main.transform;
        }

        private void Update()
        {
            // Calculate bias direction towards the camera
            Vector3 toCamera = (cameraTransform.position - transform.position).normalized;

            // Combine random drift with bias towards the camera
            Vector3 biasedDrift = Vector3.Lerp(driftDirection, toCamera, cameraBiasStrength);

            // Move the bubble upward with biased drifting
            Vector3 movement = Vector3.up * upwardSpeed * Time.deltaTime + biasedDrift * driftSpeed * Time.deltaTime;
            transform.position += movement;

            // Rotate the bubble for a more natural effect
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);

            // Check lifetime and destroy the bubble if time's up
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= lifetime)
            {
                PopBubble();
            }
        }

        private void PopBubble()
        {
            // Add effects here, like a pop sound or particle system (optional)
            Debug.Log("Bubble popped!");
            Destroy(gameObject); // Destroy the bubble object
        }
    }
}