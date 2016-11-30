// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/zTest" {
	Properties {
		_Zmax ("zMax", float) = 15.0
		_Zmin ("zMin", float) = -15.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		Pass {
           // Blend SrcAlpha One
            //ZTest LEqual
            Blend SrcAlpha OneMinusSrcAlpha
            CGPROGRAM
            #pragma 
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            float _Zmax;
            float _Zmin;

            struct v2f {
                float4 position : SV_POSITION;
                fixed4 color    : COLOR;
                float2 uv       : TEXCOORD0;
                float4 worldPos : TEXCOORD1;
            };

            v2f vert(appdata_full v) {
                v2f o;
                o.position = mul(UNITY_MATRIX_MVP, v.vertex);
                o.uv       = MultiplyUV(UNITY_MATRIX_TEXTURE0, v.texcoord);
                o.color    = v.color;
                o.worldPos   = mul (unity_ObjectToWorld, v.vertex);
                return o;
            }

            fixed4 frag(v2f i) : COLOR {
                if(i.worldPos.z > 0) return fixed4(0,0,0,0);
                fixed4 c = fixed4((i.worldPos.z - _Zmin) / (_Zmax - _Zmin) , 1.0, 0, 1.0);
                return c;
            }
            ENDCG
        }
	}
	FallBack "Diffuse"
}
