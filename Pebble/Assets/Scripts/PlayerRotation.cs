using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public Transform handTransform;  // Reference to the hand's transform
    public Transform headTransform;  // Reference to the head's transform
    public float rotationSpeed = 10f; // Speed of rotation
    public float maxDistance = 2f;   // Maximum distance to influence rotation
    public float minDistance = 0.5f; // Minimum distance to influence rotation

    private float rotationAmount; // Amount of rotation on the Y-axis

    void Update()
    {
        if (handTransform != null && headTransform != null)
        {
            // Calculate the distance between the hand and the head
            float distance = Vector3.Distance(handTransform.position, headTransform.position);

            // Map the distance to a range between -360 and 360
            float normalizedDistance = Mathf.InverseLerp(minDistance, maxDistance, distance);
            rotationAmount = Mathf.Lerp(-360f, 360f, normalizedDistance);

            // Apply rotation to the player on the Y-axis
            transform.rotation = Quaternion.Euler(0, rotationAmount, 0);
        }
    }
}
