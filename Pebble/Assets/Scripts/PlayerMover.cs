using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2f;

    [SerializeField]
    private GameObject worldGrp; // Reference to the WorldGrp object

    private bool isMoving = false;
    private Rigidbody rb; // Reference to the Rigidbody component

    private Vector3 lastPosition; // To track the last position of the player

    private void Awake()
    {
        // Get the Rigidbody component attached to the player
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        // Initialize the lastPosition
        lastPosition = transform.position;
    }

    private void Update()
    {
        if (isMoving)
        {
            // Apply physics-based movement by setting the velocity of the Rigidbody
            Vector3 movement = transform.forward * moveSpeed;
            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

            // Move the WorldGrp object only if the player has moved
            if (worldGrp != null && transform.position != lastPosition)
            {
                // Move the WorldGrp object based on the player's position change
                Vector3 playerMovement = transform.position - lastPosition;
                worldGrp.transform.position -= playerMovement; // Move opposite to player

                // Update the lastPosition for future comparisons
                lastPosition = transform.position;
            }
        }
        else
        {
            // Stop the Rigidbody's movement when not moving
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
    }
}
