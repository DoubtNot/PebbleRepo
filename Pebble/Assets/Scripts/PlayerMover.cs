using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2f;

    [SerializeField]
    private GameObject worldGrp; // Reference to the WorldGrp object

    private bool isMoving = false;
    private Rigidbody rb; // Reference to the Rigidbody component

    private Vector3? lastPosition = null; // Nullable to ensure correct initialization

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isMoving)
        {
            Vector3 movement = transform.forward * moveSpeed;
            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

            if (worldGrp != null)
            {
                if (lastPosition == null)
                {
                    // Initialize lastPosition only when movement starts
                    lastPosition = transform.position;
                }

                Vector3 playerMovement = transform.position - lastPosition.Value;
                worldGrp.transform.position -= new Vector3(playerMovement.x, 0, playerMovement.z);

                lastPosition = transform.position;
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    public void MoveForward()
    {
        isMoving = true;
    }

    public void StopMove()
    {
        isMoving = false;
        lastPosition = null; // Reset lastPosition when stopping to prevent incorrect movement calculations
    }
}
