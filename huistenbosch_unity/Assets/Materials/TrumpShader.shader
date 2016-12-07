Shader "Custom/TrumpShader" {
	Properties {
		
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_ShapeTex ("Shape", 2D) = "white" {}

	}
	SubShader {
		Tags { "RenderType"="Opaque"}
		Pass {
			Tags {"LightMode"="ForwardBase"}
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			#include "UnityLightingCommon.cginc"

			#pragma target 3.0

			sampler2D _MainTex;
			sampler2D _ShapeTex;
			float4 _MainTex_ST;

			struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                fixed4 diff : COLOR0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };


			v2f vert (appdata_base v) {
				v2f o;
				o.vertex = mul (UNITY_MATRIX_MVP, v.vertex);
				o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
				half3 worldNormal = UnityObjectToWorldNormal(v.normal);
				half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));
                o.diff = nl * _LightColor0;
                //o.diff.rgb += ShadeSH9(half4(worldNormal,1));
				return o;
			}

			fixed4 frag(v2f i): SV_TARGET {
				fixed4 col = tex2D(_MainTex, i.uv);
				fixed4 shapeCol = tex2D(_ShapeTex, i.uv);
				if(shapeCol.a == 0){
					return fixed4(0,0,0,0);
				}
				col *= i.diff;
				return col;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
