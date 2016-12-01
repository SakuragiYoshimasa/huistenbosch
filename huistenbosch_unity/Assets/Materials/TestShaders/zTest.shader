// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/zTest" {
	Properties {
		_Zmax ("zMax", float) = 15.0
		_Zmin ("zMin", float) = -15.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		Pass {
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
                float4 worldNormal = mul (unity_ObjectToWorld, v.normal);
                o.color = v.color;
                //Surface test
                //if(dot(normalize(worldNormal), float3(0,0,-1)) >= 0.01){
                //o.color = v.color;
                //}else{
                //	o.color = float4(0,0,0,0);
                //}

                o.worldPos = mul (unity_ObjectToWorld, v.vertex);
                return o;
            }

            fixed4 frag(v2f i) : COLOR {
                if(i.worldPos.z > 0) return fixed4(0,0,0,0);
                if(i.color.w == 0) return float4(0,0,0,0);
        
                fixed4 c = i.color * ((i.worldPos.z - _Zmin) / (_Zmax - _Zmin));
                return fixed4(c.xyz, 1.0);
            }
            ENDCG
        }
	}
	FallBack "Diffuse"
}
