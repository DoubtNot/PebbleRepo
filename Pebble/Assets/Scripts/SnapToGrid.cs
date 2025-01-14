using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
    [SerializeField] private float snapScaleX = 1, snapScaleY = 1, snapScaleZ = 1;
    private float posX, posY, posZ;

    void Update()
    {
        // Snap position based on the object's own position
        float currentX = transform.position.x;
        float currentY = transform.position.y;
        float currentZ = transform.position.z;

        posX = (currentX >= 0f) ? (currentX + snapScaleX * 0.5f) : (currentX - snapScaleX * 0.5f);
        posX = posX - (posX % snapScaleX);

        posY = (currentY >= 0f) ? (currentY + snapScaleY * 0.5f) : (currentY - snapScaleY * 0.5f);
        posY = posY - (posY % snapScaleY);

        posZ = (currentZ >= 0f) ? (currentZ + snapScaleZ * 0.5f) : (currentZ - snapScaleZ * 0.5f);
        posZ = posZ - (posZ % snapScaleZ);

        transform.position = new Vector3(posX, posY, posZ);

        // Snap rotation to the nearest 5 degrees, setting X and Z to 0
        transform.rotation = Quaternion.Euler(0f, Mathf.Round(transform.rotation.eulerAngles.y / 5f) * 5f, 0f);
    }
}
