Shader "Custom/KaleidoscopeShader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Segments("Segments", Range(1, 20)) = 6
        _Speed("Rotation Speed", Float) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Segments;
            float _Speed;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                float2 uv = i.uv - 0.5; // Center the texture coordinates
                float time = _Time.y * _Speed; // Time factor for animation
                float angle = atan2(uv.y, uv.x) + time; // Add time-based rotation
                float radius = length(uv);
                angle = fmod(angle * _Segments / 2.0, 3.14159) / _Segments * 2.0; // Segment and repeat the angle
                uv = float2(cos(angle), sin(angle)) * radius; // Polar to Cartesian coordinates
                uv += 0.5; // Reset origin to bottom-left
                return tex2D(_MainTex, uv);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
