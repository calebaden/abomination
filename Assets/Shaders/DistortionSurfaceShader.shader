Shader "Custom/DistortionSurfaceShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0

		_DistortZone("DistortTime", float) = 0.8
		_Distorting("Distorting", Range(0,1)) = 0
		_DistortStrength("DistortStrength", float) = 0

		_PulseTime("PulseTime", float) = 0
		_PulseStrength("PulseStrength", float) = 0
		_Pulsing("Pulsing", Range(0,1)) = 1
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
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		
		float _DistortZone;
		float _DistortStrength;
		float _Distorting;

		float _PulseTime;
		float _PulseStrength;
		float _Pulsing;

		void vert(inout appdata_full v)
		{
			if (_Distorting == 1)
			{
				float t = sin(v.vertex.y) * _DistortZone;
				float waveVal = sin(2 * 3.14 * 262 * t) + sin(2 * 3.14 * 262 * 3 * t) / 3 + sin(2 * 3.14 * 262 * 5 * t) / 5 + sin(2 * 3.14 * 262 * 7 * t) / 7;
				v.vertex.x += waveVal / 10 * sin(_Time) * _DistortStrength;
			}

			if(_Pulsing == 1)
			{
				if (v.vertex.y != 0 && abs(v.vertex.y - _PulseTime) < 0.2)
				{
					float multi = 1;
					if (v.vertex.x < 0)
					{
						multi = -1;
					}

					v.vertex.x += clamp(abs((_PulseTime / v.vertex.y) * sin(v.vertex.y - _PulseTime)) * multi * _PulseStrength, -2, 2);
				}
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
