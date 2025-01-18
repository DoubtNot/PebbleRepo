using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2f;

    [SerializeField]
    private Transform playerTransform; // Reference to the player object

    private bool isMoving = false;

    private void Update()
    {
        if (isMoving && playerTransform != null)
        {
            // Flip the forward movement by using the opposite direction
            transform.position += -playerTransform.forward * moveSpeed * Time.deltaTime;
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
