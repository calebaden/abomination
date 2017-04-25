﻿Shader "Custom/car" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_Music("Music", float) = 0.0
		_Music2("Music2", float) = 0.0
		_Scale("Scale", float) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows vertex:vert

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
			float3 objPos;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		float _Music;
		float _Music2;
		float _Scale;
		void vert(inout appdata_full v, out Input o) {
			UNITY_INITIALIZE_OUTPUT(Input, o);
			

			o.objPos = v.vertex;
			if (abs(v.vertex.x - _Music)< 0.5f) 
			{
				
				/*v.vertex.xyz += v.normal *(_Music / v.vertex.y)*0.3f;*/
			}
		}


		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
	

			float b = IN.objPos.x - _Scale;
			float a = abs(b - _Music);
		/*	a -= _Scale;*/
			o.Albedo.r =saturate( 1 - a * 2);

		/*	float b = abs(IN.worldPos.x - _Music2);
			o.Albedo.g = saturate(1 - a * 2);
			*/
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
