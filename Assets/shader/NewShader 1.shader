Shader "Custom/NewShader1" {
	Properties{
		_RimColor("Rim Color", COLOR) = (0.5, 0.5, 0.5, 0.5)
	}

	SubShader {
		Tags { "RenderType"="Opaque" }
		
		CGPROGRAM
		#pragma surface surf Lambert
		
		struct Input{
			float4 color : COLOR;
		};
		
		float4 _RimColor;
		
		void surf (Input IN, inout SurfaceOutput o) {
			//half4 c = tex2D (_MainTex, IN.uv_MainTex);
			//o.Albedo = c.rgb;
			//o.Alpha = c.a;
			o.Albedo = _RimColor.rgb;
			o.Alpha = _RimColor.a;
		}
		ENDCG
	} 
}
