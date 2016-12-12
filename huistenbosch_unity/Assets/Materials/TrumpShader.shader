Shader "Custom/TrumpShader" {
	Properties {
		
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_ShapeTex ("Shape", 2D) = "white" {}

	}
	SubShader {
		Tags { "RenderType" = "Opaque" "Queue" = "Transparent" }


		Blend SrcAlpha OneMinusSrcAlpha
		CGPROGRAM

		#include "UnityCG.cginc"
		#include "UnityLightingCommon.cginc"

		sampler2D _MainTex;
		sampler2D _ShapeTex;
	
		#pragma surface surf Lambert alpha:fade
		struct Input {
			float2 uv_MainTex;
		};


		void surf(Input IN, inout SurfaceOutput o) {
			o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;

			fixed4 col = tex2D(_MainTex, IN.uv_MainTex);
			fixed4 shapeCol = tex2D(_ShapeTex, IN.uv_MainTex);
			if (shapeCol.a == 0) {
				o.Albedo = fixed3(0, 0, 0);
				o.Alpha = 0;
				return;
			}
	
			o.Albedo = col.rgb;
			o.Alpha = 1.0;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
