using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    // Public variables to adjust the movement values in the Inspector
    public float moveUpValue = 0.025f;
    public float moveDownValue = 0.025f;
    public float moveLeftValue = 0.025f;
    public float moveRightValue = 0.025f;
    public float moveForwardValue = 0.025f;
    public float moveBackValue = 0.025f;
    public float rotateLeftValue = 5f;
    public float rotateRightValue = 5f;

    // Move the object upwards
    public void MoveUp()
    {
        transform.position += Vector3.up * moveUpValue;
    }

    // Move the object downwards
    public void MoveDown()
    {
        transform.position += Vector3.down * moveDownValue;
    }

    // Move the object to the left
    public void MoveLeft()
    {
        transform.position += Vector3.left * moveLeftValue;
    }

    // Move the object to the right
    public void MoveRight()
    {
        transform.position += Vector3.right * moveRightValue;
    }

    // Move the object forward
    public void MoveForward()
    {
        transform.position += Vector3.forward * moveForwardValue;
    }

    // Move the object backward
    public void MoveBack()
    {
        transform.position += Vector3.back * moveBackValue;
    }

    // Rotate the object to the left
    public void RotateLeft()
    {
        transform.Rotate(Vector3.up, -rotateLeftValue);
    }

    // Rotate the object to the right
    public void RotateRight()
    {
        transform.Rotate(Vector3.up, rotateRightValue);
    }
}
