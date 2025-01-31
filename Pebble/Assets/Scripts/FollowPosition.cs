using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    [SerializeField] private Transform target; // Reference to the target object
    [SerializeField] private Vector3 positionOffset = Vector3.zero; // Default position offset
    [SerializeField] private Vector3 rotationOffset = Vector3.zero; // Default rotation offset
    [SerializeField] private Vector3 scaleMultiplier = Vector3.one; // Default scale multiplier

    [SerializeField] private bool followPosition = true;
    [SerializeField] private bool followRotation = true;
    [SerializeField] private bool followScale = true;

    private void Update()
    {
        if (target != null)
        {
            if (followPosition)
            {
                transform.position = target.position + positionOffset;
            }

            if (followRotation)
            {
                transform.rotation = target.rotation * Quaternion.Euler(rotationOffset);
            }

            if (followScale)
            {
                transform.localScale = Vector3.Scale(target.localScale, scaleMultiplier);
            }
        }
    }
}
