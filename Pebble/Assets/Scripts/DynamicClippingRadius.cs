using UnityEngine;

public class DynamicClippingRadius : MonoBehaviour
{
    public Material clippingMaterial; // Reference to the material using the shader
    public Transform targetScaler;    // Object whose movement affects the clipping radius
    public float minRadius = 1f;      // Minimum clipping radius
    public float maxRadius = 10f;     // Maximum clipping radius
    public float defaultRadius = 0.5f; // Default clipping radius

    private float initialLocalZ; // Stores the initial local Z position of targetScaler

    void Start()
    {
        if (targetScaler != null)
        {
            initialLocalZ = targetScaler.localPosition.z; // Store initial local Z position
        }

        if (clippingMaterial != null)
        {
            clippingMaterial.SetFloat("_ClipRadius", defaultRadius);
        }
    }

    void Update()
    {
        if (clippingMaterial != null && targetScaler != null)
        {
            float zDifference = initialLocalZ - targetScaler.localPosition.z; // Use localPosition to track only child movement
            float newRadius = Mathf.Clamp(defaultRadius + zDifference, minRadius, maxRadius);

            // Update only the radius
            clippingMaterial.SetFloat("_ClipRadius", newRadius);
        }
    }
}
