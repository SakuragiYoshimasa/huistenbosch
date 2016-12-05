Shader "Custom/PureColor" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_ShapeTex ("Shape", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		Pass{
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag 
			#include "UnityCG.cginc"

			struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

			struct v2f {
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			fixed4 _Color;
			sampler2D _ShapeTex;
			float4 _ShapeTex_ST;

			v2f vert (appdata v) {
				v2f o;
				o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _ShapeTex);
				return o;
			}

			fixed4 frag(v2f i): COLOR {
				fixed4 shapeCol = tex2D(_ShapeTex, i.uv);
				if(shapeCol.a == 0){
					return fixed4(0,0,0,0);
				}
				return _Color;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
