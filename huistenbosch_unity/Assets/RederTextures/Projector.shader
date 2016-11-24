// Upgrade NOTE: replaced '_Projector' with 'unity_Projector'

Shader "Custom/Projector" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_ProjectorPos ("Pos", Vector) = (0,0,0,0)
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		Pass {
			ZTest LEqual
			ZWrite On
			//Offset -1, -1
			Cull Back
			Blend SrcAlpha OneMinusSrcAlpha
			//BlendOp Max
			//Blend One One
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			sampler2D _MainTex;
			float4x4 unity_Projector;
			float4 _ProjectorPos;//

			struct v2f {
    			float4 pos : SV_POSITION;
    			float2 uv : TEXCOORD0;
    			float2 naiseki : TEXCOORD1;//
			};

			float4 _MainTex_ST;

			v2f vert (appdata_base v)
			{

			    v2f o;

			    float4 origin = v.vertex;//
			    o.naiseki.x = dot(normalize( _ProjectorPos - origin), v.normal);//


			    o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
			    float4 p = mul(unity_Projector, v.vertex);
			    o.uv = p.xy / p.w;
			    return o;
			}

			half4 frag (v2f i) : COLOR
			{

				if(i.naiseki.x < 0){
					
					return float4(0,0,0,0);
				}
				
				float4 c = tex2D (_MainTex, i.uv);
				if(c.x == 0 && c.y == 0 && c.z == 0){
					c.w = 0;
				}
			    return c;
			}
            ENDCG
		} //end pass

	} 
	FallBack Off
}