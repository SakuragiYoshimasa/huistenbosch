// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

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
			Offset -1, -1
			Cull Back
			//Blend SrcAlpha OneMinusSrcAlpha
			BlendOp Max
			//BlendOp Add
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
    			float4 naiseki : TEXCOORD1;
			};

			float4 _MainTex_ST;

			v2f vert (appdata_base v)
			{

			    v2f o;


			    float3 origin = v.vertex.xyz;
			   //	float3 origin = o.pos;
			    //o.naiseki.x = dot(normalize(_ProjectorPos.xyz - mul(UNITY_MATRIX_MVP ,origin)), normalize(mul(UNITY_MATRIX_MVP, v.normal)));//
			    o.naiseki.x = dot(normalize(_ProjectorPos.xyz - origin),  mul(v.normal, unity_WorldToObject));//

			    // o.naiseki.xyzw = normalize(mul(v.normal, _World2Object));
			    // o.naiseki.xyzw = mul(v.normal, _World2Object) * 10;
			   //  o.naiseki.xyz = normalize(o.naiseki.xyzw);
			   // o.naiseki.xyz = v.normal;
			    o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
			    float4 p = mul(unity_Projector, v.vertex);
			    o.uv = p.xy / p.w;
			    return o;
			}

			half4 frag (v2f i) : COLOR
			{
				float4 c1;
				c1.xyz = i.naiseki.xyz; 
				c1.w = 1.0;
				//return c1;
				//return float4(i.naiseki.x,i.naiseki.x,i.naiseki.x,1.0);
				if(i.naiseki.x < 0.1){
					
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