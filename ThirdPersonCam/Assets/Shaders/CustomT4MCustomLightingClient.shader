Shader "Custom/T4MCustomLightingClient" 
{
	Properties 
	{
		_Controller("Controller", 2D) = "white" {}
		_BaseTex("BaseTex", 2D) = "white" {}
		_Tex1("Tex1", 2D) = "white" {}
		_Tex2("Tex2", 2D) = "white" {}
		_Tex3("Tex3", 2D) = "white" {}
		[HideInInspector]_TexScale("_TexScale", float) = 128
	}
    
	SubShader
	{
		Tags 
		{
		   "RenderType" = "Opaque"
		}
		
		CGPROGRAM
		#pragma surface surf Lambert
		#pragma exclude_renderers xbox360 ps3
		#include "UnityCG.cginc"

		struct Input 
		{
			float2 uv_Controller : TEXCOORD0;
		};
		
		sampler2D _Controller, _BaseTex, _Tex1, _Tex2, _Tex3;
		float4 _BaseTex_ST, _Tex1_ST, _Tex2_ST, _Tex3_ST;
		float _TexScale;
		
		void surf (Input IN, inout SurfaceOutput o) 
		{
			float2 uv0 = float2(IN.uv_Controller.x, 1.0 - IN.uv_Controller.y);
			float2 uv1 = uv0 * _TexScale;

			////// Lighting:
			float4 cBottom = tex2D(_BaseTex, TRANSFORM_TEX(uv1, _BaseTex));
			float4 c0 = tex2D(_Tex1, TRANSFORM_TEX(uv1, _Tex1));
			float4 c1 = tex2D(_Tex2, TRANSFORM_TEX(uv1, _Tex2));
			float4 c2 = tex2D(_Tex3, TRANSFORM_TEX(uv1, _Tex3));
			
			float3 B = tex2D(_Controller, uv0).rgb;

			float4 fLayer = cBottom;
			fLayer = B.r * fLayer + (1 - B.r) * c0;
			fLayer = B.g * fLayer + (1 - B.g) * c1;
			fLayer = B.b * fLayer + (1 - B.b) * c2;

			o.Alpha = 0.0;
			o.Albedo.rgb = fLayer.rgb;
		}

		ENDCG 
	}

	// Fallback to Diffuse
	Fallback "Diffuse"
}
