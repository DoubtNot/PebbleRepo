Shader "Custom/SquareClippingShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}                      // Base texture
        _ClipCenter ("Clip Center", Vector) = (0.0, 0.0, 0.0, 0)  // Center of the clipping sphere
        _ClipRadius ("Clip Radius", Float) = 5.0                   // Radius of the clipping sphere
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
        float4 _ClipCenter; // Center of the clipping sphere
        float _ClipRadius;  // Radius of the clipping sphere
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

            // Compute the distance from the fragment to the clip center
            float dist = distance(IN.worldPos, _ClipCenter.xyz);

            // Clip fragments outside the sphere
            if (dist > _ClipRadius)
            {
                clip(-1); // Discard pixels outside the bounds
            }
        }
        ENDCG
    }
    FallBack "Diffuse"
}
