Shader "Custom/SquareClippingShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {} // Base texture
        _ClipMin ("Clip Min Bounds", Vector) = (-5.0, -5.0, -5.0, 0) // Min bounds of the clipping cube
        _ClipMax ("Clip Max Bounds", Vector) = (5.0, 5.0, 5.0, 0)    // Max bounds of the clipping cube
        _Glossiness ("Smoothness", Range(0,1)) = 0.5                 // Smoothness for lighting
        _Metallic ("Metallic", Range(0,1)) = 0.0                     // Metallic for lighting
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        sampler2D _MainTex;
        float4 _ClipMin; // Minimum bounds (x, y, z)
        float4 _ClipMax; // Maximum bounds (x, y, z)
        float _Glossiness; // Smoothness
        float _Metallic;   // Metallic

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

            // Clip fragments outside the square bounds
            if (IN.worldPos.x < _ClipMin.x || IN.worldPos.x > _ClipMax.x ||
                IN.worldPos.y < _ClipMin.y || IN.worldPos.y > _ClipMax.y ||
                IN.worldPos.z < _ClipMin.z || IN.worldPos.z > _ClipMax.z)
            {
                clip(-1); // Discard pixels outside the bounds
            }
        }
        ENDCG
    }
    FallBack "Diffuse"
}
