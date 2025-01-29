using UnityEngine;

public class SetAsChild : MonoBehaviour
{
    [SerializeField] private Transform world; // Reference to the World object

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Building"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Building"))
        {
            other.transform.SetParent(world);
        }
    }
}