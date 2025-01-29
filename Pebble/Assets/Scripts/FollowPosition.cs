using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    [SerializeField] private Transform target; // Reference to the target object
    [SerializeField] private Vector3 offset = Vector3.zero; // Default offset (0,0,0)

    private void Update()
    {
        if (target != null)
        {
            // Apply the offset to the position
            transform.position = target.position + offset;
        }
    }
}
