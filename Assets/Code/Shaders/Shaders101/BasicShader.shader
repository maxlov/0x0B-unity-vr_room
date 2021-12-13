// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Shader101/Basic"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Color("Color", Color) = (1, 1, 1, 1)
        _Tile("Tiling", int) = 1
    }

    SubShader
    {
        Tags 
        { 
            "Queue" = "Transparent"
        }
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv :TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv :TEXCOORD0;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            fixed4 _Color;
            int _Tile;

            fixed4 frag(v2f i) : SV_Target
            {
                float4 texSamp = tex2D(_MainTex, i.uv * _Tile);
                float luminance = 0.3 * texSamp.r + 0.59 * texSamp.g + 0.11 * texSamp.b;
                float4 color = float4(luminance, luminance, luminance, texSamp.a) * _Color;
                return color;
            }
            ENDCG
        }
    }
}
