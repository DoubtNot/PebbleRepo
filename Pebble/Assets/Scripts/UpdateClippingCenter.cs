using UnityEngine;

public class UpdateClippingCenter : MonoBehaviour
{
    public Material clippingMaterial; // Reference to the material using the shader
    public Transform clippingCenterObject; // GameObject used as the center of the clipping region
    public Vector3 clippingSize = new Vector3(10f, 10f, 10f); // Size of the clipping cube

    void Update()
    {
        if (clippingMaterial != null && clippingCenterObject != null)
        {
            // Update the center of the clipping region
            clippingMaterial.SetVector("_ClipCenter", clippingCenterObject.position);

            // Update the size of the clipping region
            clippingMaterial.SetVector("_ClipSize", clippingSize);
        }
    }
}
