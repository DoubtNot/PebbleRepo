using UnityEngine;

public class TransformRestraints : MonoBehaviour
{
    [SerializeField] private bool restrainPosition = false;
    [SerializeField] private bool restrainRotation = false;
    [SerializeField] private bool restrainScale = false;

    [SerializeField] private bool restrainPosX = false;
    [SerializeField] private bool restrainPosY = false;
    [SerializeField] private bool restrainPosZ = false;

    [SerializeField] private bool restrainRotX = false;
    [SerializeField] private bool restrainRotY = false;
    [SerializeField] private bool restrainRotZ = false;

    [SerializeField] private bool restrainScaleX = false;
    [SerializeField] private bool restrainScaleY = false;
    [SerializeField] private bool restrainScaleZ = false;

    [SerializeField] private Vector3 positionLock = Vector3.zero;
    [SerializeField] private Vector3 rotationLock = Vector3.zero;
    [SerializeField] private Vector3 scaleLock = Vector3.one;

    private void LateUpdate()
    {
        if (restrainPosition)
        {
            transform.position = new Vector3(
                restrainPosX ? positionLock.x : transform.position.x,
                restrainPosY ? positionLock.y : transform.position.y,
                restrainPosZ ? positionLock.z : transform.position.z
            );
        }

        if (restrainRotation)
        {
            transform.rotation = Quaternion.Euler(
                restrainRotX ? rotationLock.x : transform.rotation.eulerAngles.x,
                restrainRotY ? rotationLock.y : transform.rotation.eulerAngles.y,
                restrainRotZ ? rotationLock.z : transform.rotation.eulerAngles.z
            );
        }

        if (restrainScale)
        {
            transform.localScale = new Vector3(
                restrainScaleX ? scaleLock.x : transform.localScale.x,
                restrainScaleY ? scaleLock.y : transform.localScale.y,
                restrainScaleZ ? scaleLock.z : transform.localScale.z
            );
        }
    }
}
