using UnityEngine;

public class UpdateClippingCenter : MonoBehaviour
{
    public Material clippingMaterial; // Reference to the material using the shader
    public Transform clippingCenterObject; // GameObject used as the center of the clipping region

    void Update()
    {
        if (clippingMaterial != null && clippingCenterObject != null)
        {
            // Update the center of the clipping region
            clippingMaterial.SetVector("_ClipCenter", clippingCenterObject.position);
        }
    }
}
