Shader "Hidden/TerrainEngine/Details/WavingDoublePass" {
Properties {
	_WavingTint ("Fade Color", Color) = (.7,.6,.5, 0)
	_MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
	_WaveAndDistance ("Wave and distance", Vector) = (12, 3.6, 1, 1)
	_Cutoff ("Cutoff", float) = 0.5
}

SubShader {
	Tags {
		"Queue" = "Geometry+200"
		"IgnoreProjector"="True"
		"RenderType"="Grass"
		"DisableBatching"="True"
	}
	Cull Off
	LOD 200
	ColorMask RGB
		
CGPROGRAM

#pragma surface surf Lambert vertex:WavingGrassVert addshadow exclude_path:deferred
#include "../../CGIncludes/HB_Core.cginc"
#include "../../CGIncludes/HB_TerrainEngine.cginc"

sampler2D _MainTex;
fixed _Cutoff;

struct Input {
	float2 uv_MainTex;
	fixed4 color : COLOR;
};

void surf (Input IN, inout SurfaceOutput o) {
	fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * IN.color;
	o.Albedo = c.rgb;
	o.Alpha = c.a;
	clip (o.Alpha - _Cutoff);
	o.Alpha *= IN.color.a;
}
ENDCG
}
	
	SubShader {
		Tags {
			"Queue" = "Geometry+200"
			"IgnoreProjector"="True"
			"RenderType"="Grass"
		}
		Cull Off
		LOD 200
		ColorMask RGB
		
		Pass {
			Tags { "LightMode" = "Vertex" }
			CGPROGRAM
			
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog
			#include "UnityCG.cginc"
			#include "../../CGIncludes/HB_Core.cginc"

			struct v2f {
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				fixed4 diff : COLOR0;
				float4 pos : SV_POSITION;
			};

			uniform float4 _MainTex_ST;
			uniform fixed _Cutoff;


			struct appdata_color {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 texcoord : TEXCOORD0;
				fixed4 color : COLOR;
			};
			

			v2f vert(appdata_color v)
			{
				v2f o;
				
				HB(v.vertex)
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = TRANSFORM_TEX(v.texcoord,_MainTex);
				float4 diffuse = float4(ShadeVertexLightsFull(v.vertex, v.normal, 4, true), 1.0f);
				o.diff = diffuse * v.color;
				UNITY_TRANSFER_FOG(o,o.pos);
				return o;
			}

			uniform sampler2D _MainTex;

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 temp = tex2D(_MainTex, i.uv);
				fixed4 c;
				c.xyz = temp.xyz * i.diff.xyz;
				c.w = temp.w;// *i.diff.w;
				UNITY_APPLY_FOG(i.fogCoord, c);
				clip(c.w - _Cutoff);
				return c;
			}
			ENDCG
		}
		Pass {
			Tags { "LightMode" = "VertexLMRGBM" }
			AlphaTest Greater [_Cutoff]
			CGPROGRAM

			
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog

			#include "UnityCG.cginc"
			#include "../../CGIncludes/HB_Core.cginc"
			struct v2f {
				half2 uv : TEXCOORD0;
				half2 uv2 : TEXCOORD1;
				UNITY_FOG_COORDS(2)
				float4 pos : SV_POSITION;
			};

			uniform float4 _MainTex_ST;

			v2f vert(float4 vertex : POSITION, float2 uv : TEXCOORD0, float2 uv2 : TEXCOORD1)
			{
				v2f o;
				
				HB(vertex)
				o.pos = mul(UNITY_MATRIX_MVP, vertex);
				o.uv = TRANSFORM_TEX(uv,_MainTex);
				o.uv2 = uv2 * unity_LightmapST.xy + unity_LightmapST.zw;
				UNITY_TRANSFER_FOG(o,o.pos);
				return o;
			}

			uniform sampler2D _MainTex;
			uniform fixed4 _Color;
			uniform fixed _Cutoff;

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 lm = UNITY_SAMPLE_TEX2D(unity_Lightmap, i.uv2);
				lm *= lm.a * 2;
				fixed4 c = tex2D(_MainTex, i.uv);
				c.rgb *= lm.rgb * 4;
				UNITY_APPLY_FOG(i.fogCoord, c);
				clip(c.w - _Cutoff);
				return c;
			}
			ENDCG
		}
	}
	
	Fallback Off
}
