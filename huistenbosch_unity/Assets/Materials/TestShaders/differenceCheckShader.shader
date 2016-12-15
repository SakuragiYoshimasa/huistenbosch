Shader "Custom/differenceCheckShader" {
	Properties {
		_PreRenderedTex ("PreRendered", 2D) = "white" {}
		_RltRenderingTex("RealTimeRendering", 2D) = "white" {}
	}
	SubShader{
		Tags{ "RenderType" = "Opaque" }
		Pass {
			
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			sampler2D _PreRenderedTex;
			sampler2D _RltRenderingTex;

			struct v2f{
				float4 position : SV_POSITION;
				fixed4 color : COLOR;
				float2 uv       : TEXCOORD0;
				float4 worldPos : TEXCOORD1;
			};

			v2f vert(appdata_full v)
			{
				v2f o;
				o.position = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = MultiplyUV(UNITY_MATRIX_TEXTURE0, v.texcoord);
				float4 worldNormal = mul(unity_ObjectToWorld, v.normal);
				o.color = v.color;
				o.worldPos = mul(unity_ObjectToWorld, v.vertex);
				return o;
			}

			fixed4 frag(v2f i) : COLOR {
				fixed4 col;
				col.w = 1.0;
				float4 preRenderedCol = tex2D(_PreRenderedTex, i.uv);
				float4 rltRenderingCol = tex2D(_RltRenderingTex, i.uv);

				if (preRenderedCol.x > 0 || preRenderedCol.y > 0 || preRenderedCol.z > 0) {
					if (rltRenderingCol.x > 0 || rltRenderingCol.y > 0 || rltRenderingCol.z > 0) {
						col.xyz = fixed3(0, 0, 0);
					}
					else {
						col.xyz = fixed3(1.0, 0, 0);
					}
				}
				else {

					if (rltRenderingCol.x > 0 || rltRenderingCol.y > 0 || rltRenderingCol.z > 0) {
						col.xyz = fixed3(1.0, 0, 0);
					}
					else {
						col.xyz = fixed3(0, 0, 0);
					}
				}

				return col;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
