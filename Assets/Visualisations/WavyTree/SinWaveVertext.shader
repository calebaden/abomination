﻿Shader "Custom/SinWaveVertext" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_Music("Music",Range(0,1)) = 0.0
		_Speed("Speed", float) = 0.0
		_Frequency("Frequency",float) = 0.0
		_Distance("Distance",float) = 0.0
		_Dist("Dist",Vector) = (0,0,0,0)
		_Pulse("Pulse", int) = 0

	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
#include "Assets/Battlehub/HorizonBending/Shaders/CGIncludes/HB_Core.cginc"
#pragma enable_d3d11_debug_symbols

		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows vertex:vert addshadow

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

		float _Speed;//how fast the model waves
		float _Frequency;//the frequency of waves
		float _Distance;//the amount the pixels moves along its axis
		float _Offset;
		float4 _Dist;
		bool _Pulse;
		float _Music;

		void vert(inout appdata_full v, out Input o)
		{
			HB(v.vertex);
			UNITY_INITIALIZE_OUTPUT(Input, o);

			float yDist = _Dist.y - v.vertex.y;
			//abs the vertex.y value so that the bottom of the model is 0 instead of the middle. Then offset this value by the position of the player so the vertexes align with the rotating world
			float a = abs(v.vertex.y + .5) - yDist;

			//do a sin wave along the model. The higher the pixel, the more it moves
			v.vertex.x += sin((_Time.y * _Speed) + v.vertex.y * _Frequency) * ((_Distance * a));

			if (_Pulse > 0)
			{
				float b = abs(v.vertex.y - _Music);
				v.vertex.xyz += v.normal * saturate(1 - b * 2);
			}
		}

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
