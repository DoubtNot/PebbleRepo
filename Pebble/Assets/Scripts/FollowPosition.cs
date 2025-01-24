using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    [SerializeField]
    private Transform target; // Reference to the target object

    private void Update()
    {
        if (target != null)
        {
            // Match the position of the attached object to the target
            transform.position = target.position;
        }
    }
}
