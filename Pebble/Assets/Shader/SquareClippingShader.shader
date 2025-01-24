Shader "Custom/SquareClippingShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}                      // Base texture
        _ClipCenter ("Clip Center", Vector) = (0.0, 0.0, 0.0, 0)  // Center of the clipping cube
        _ClipSize ("Clip Size", Vector) = (10.0, 10.0, 10.0, 0)    // Size of the clipping cube
        _Glossiness ("Smoothness", Range(0,1)) = 0.5              // Smoothness for lighting
        _Metallic ("Metallic", Range(0,1)) = 0.0                  // Metallic for lighting
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        sampler2D _MainTex;
        float4 _ClipCenter; // Center of the clipping region (x, y, z)
        float4 _ClipSize;   // Half-size of the clipping region (width, height, depth)
        float _Glossiness;  // Smoothness
        float _Metallic;    // Metallic

        struct Input
        {
            float2 uv_MainTex; // UV coordinates for the texture
            float3 worldPos;   // World position of the fragment
        };

        // Surface shader function
        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            // Sample the texture
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;         // Base color
            o.Metallic = _Metallic;   // Metallic property
            o.Smoothness = _Glossiness; // Smoothness property

            // Compute the min and max bounds based on the center and size
            float3 clipMin = _ClipCenter.xyz - _ClipSize.xyz * 0.5;
            float3 clipMax = _ClipCenter.xyz + _ClipSize.xyz * 0.5;

            // Clip fragments outside the cube bounds
            if (IN.worldPos.x < clipMin.x || IN.worldPos.x > clipMax.x ||
                IN.worldPos.y < clipMin.y || IN.worldPos.y > clipMax.y ||
                IN.worldPos.z < clipMin.z || IN.worldPos.z > clipMax.z)
            {
                clip(-1); // Discard pixels outside the bounds
            }
        }
        ENDCG
    }
    FallBack "Diffuse"
}
