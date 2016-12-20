Shader "Custom/PureColor" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_ShapeTex ("Shape", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" "Queue" = "Transparent" }
		
		Blend SrcAlpha OneMinusSrcAlpha
		CGPROGRAM
		#pragma surface surf Lambert alpha:fade
		
		struct Input {
			
			float2 uv_ShapeTex;
		};

		
		sampler2D _ShapeTex;
		fixed4 _Color;


		void surf(Input IN, inout SurfaceOutput o) {
			
			fixed4 shapeCol = tex2D(_ShapeTex, IN.uv_ShapeTex);
			if (shapeCol.r == 0 && shapeCol.g == 0 && shapeCol.b == 0) {
				o.Albedo = fixed3(0, 0, 0);
				o.Alpha = 0;
				//return;
			}
			else {
				o.Albedo = _Color.rgb;
				o.Alpha = 1.0;
			}
		}
		ENDCG
	}
	FallBack "Diffuse"
}
