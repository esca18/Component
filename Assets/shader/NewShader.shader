Shader "Custom/NewShader" {
	SubShader {
		Tags { "RenderType"="Opaque" }	
		CGPROGRAM
		#pragma surface surf Lambert
		#pragma debug
		struct Input{
			float4 color : COLOR;
		};

		void surf (Input IN, inout SurfaceOutput o) {			
			o.Albedo = 0.5;
		}
		ENDCG
	} 
}
