using UnityEngine;
using UnityEngine.Events;

public class CollisionBehavior : MonoBehaviour
{
    public UnityEvent collisionEnterEvent, collisionExitEvent;

    // Variable to specify a tag for collision detection
    [SerializeField] private string collisionTag = ""; // If empty, it won't filter by tag

    private void OnCollisionEnter(Collision collision)
    {
        // Check if a tag is specified, and if so, ensure the collided object has that tag
        if (!string.IsNullOrEmpty(collisionTag) && !collision.gameObject.CompareTag(collisionTag))
        {
            return; // Exit if the collided object's tag doesn't match
        }

        collisionEnterEvent.Invoke();
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if a tag is specified, and if so, ensure the collided object has that tag
        if (!string.IsNullOrEmpty(collisionTag) && !collision.gameObject.CompareTag(collisionTag))
        {
            return; // Exit if the collided object's tag doesn't match
        }

        collisionExitEvent.Invoke();
    }
}
