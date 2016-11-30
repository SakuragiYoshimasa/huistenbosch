// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/zTest" {
	Properties {
		_Zmax ("zMax", float) = 15.0
		_Zmin ("zMin", float) = -15.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }

		
		Pass {
            Blend SrcAlpha One
            ZTest LEqual
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define PI 3.14159

            #include "UnityCG.cginc"

            float _Zmax;
            float _Zmin;

            struct v2f {
                float4 position : SV_POSITION;
                fixed4 color    : COLOR;
                float2 uv       : TEXCOORD0;
                float4 worldPos   : TEXCOORD1;
            };

            v2f vert(appdata_full v) {
                //float bend = sin(PI * _Time.x * 1000 / 45 + v.vertex.y + v.vertex.x);
                //float x = sin(v.texcoord.x * PI) - 1.0;
                //float y = sin(v.texcoord.y * PI) - 1.0;
                //v.vertex.y += _BendScale * bend * (x + y);

                v2f o;
                o.position = mul(UNITY_MATRIX_MVP, v.vertex);
                o.uv       = MultiplyUV(UNITY_MATRIX_TEXTURE0, v.texcoord);
                o.color    = v.color;
                o.worldPos   = mul (unity_ObjectToWorld, v.vertex);
                return o;
            }

            fixed4 frag(v2f i) : COLOR {
                //fixed4 tex = tex2D(_MainTex, i.uv);
                //tex.rgb *= i.color.rgb;
                //tex.a   *= i.color.a;
                fixed4 c = fixed4(0 , 1.0, (i.worldPos.z - _Zmin) / (_Zmax - _Zmin), 1.0);
                return c;
            }
            ENDCG
        }

	}
	FallBack "Diffuse"
}
