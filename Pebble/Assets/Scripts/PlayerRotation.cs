using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public Transform rightHandTransform; // Reference to the right hand's transform
    public Transform leftHandTransform;  // Reference to the left hand's transform
    public float rotationSpeed = 10f;    // Speed of rotation

    void Update()
    {
        if (rightHandTransform != null && leftHandTransform != null)
        {
            // Calculate the difference in the Y-axis position between the hands
            float yDifference = rightHandTransform.position.y - leftHandTransform.position.y;

            // Determine the rotation amount based on the difference
            float rotationAmount = yDifference * rotationSpeed;

            // Apply rotation to the player on the Y-axis
            transform.rotation = Quaternion.Euler(0, rotationAmount, 0);
        }
    }
}
