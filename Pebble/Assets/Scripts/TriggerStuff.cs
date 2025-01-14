using UnityEngine;
using UnityEngine.Events;

public class TriggerStuff : MonoBehaviour
{
    public UnityEvent triggerEnterEvent, triggerExitEvent;

    // Field to filter objects by tag
    public string filterTag = "";

    private void OnTriggerEnter(Collider other)
    {
        // Check if a tag is specified, and if so, filter by that tag
        if (!string.IsNullOrEmpty(filterTag) && !other.CompareTag(filterTag))
        {
            return; // Exit if the object's tag doesn't match the specified tag
        }

        triggerEnterEvent.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if a tag is specified, and if so, filter by that tag
        if (!string.IsNullOrEmpty(filterTag) && !other.CompareTag(filterTag))
        {
            return; // Exit if the object's tag doesn't match the specified tag
        }

        triggerExitEvent.Invoke();
    }
}
