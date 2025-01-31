using UnityEngine;

public class InitialPosition : MonoBehaviour
{
    [SerializeField] private Transform target; // Reference to the target object

    private void Start()
    {
        if (target != null)
        {
            transform.position = target.position;
            transform.rotation = target.rotation;
        }
    }
}
