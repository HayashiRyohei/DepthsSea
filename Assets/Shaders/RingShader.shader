Shader "Custom/RingShader" {
	Properties {
	    // properties for water shader
	    _MainTex ("Texture", 2D) = "white" { }
		
		_Color ("Color", Color) = (1.0, 1.0, 1.0, 1.0)
	    _InnerRadius ("Inner Radius", Range (0.0, 1.0)) = 0.2
	    _OuterRadius ("Outer Radius", Range (0.0, 1.0)) = 0.3

		_InnerBlurThickness ("Inner Blur Thickness", Range(0.0, 1.0)) = 0.0001
		_OuterBlurThickness ("Outer Blur Thickness", Range(0.0, 1.0)) = 0.0001
	} 
	
	SubShader {
		//透過処理用
		Tags { "RenderType" = "Transparent" "Queue"="Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha

		Pass {
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			
			uniform float4 _Color;
			uniform float _InnerRadius;
			uniform float _OuterRadius;

			uniform float _InnerBlurThickness;
			uniform float _OuterBlurThickness;

			struct v2f {
			    float4  pos : SV_POSITION;
			    float2  uv : TEXCOORD0;
			};
			
			float4 _MainTex_ST;
			
			v2f vert (appdata_base v)
			{
			    v2f o;
			    o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
			    o.uv = TRANSFORM_TEX (v.texcoord, _MainTex);
			    return o;
			}
			
			half4 frag (v2f i) : COLOR
			{
		    	    half4 texcol = tex2D(_MainTex, i.uv) * _Color;
		    	    float dist = distance(i.uv, float2(0.5,0.5));
		    	    if(dist < _InnerRadius - _InnerBlurThickness) {
						clip(-1.0);
		    	    } else if(dist < _InnerRadius) {
						//αを調整
						texcol.w *= (dist - (_InnerRadius - _InnerBlurThickness)) / _InnerBlurThickness;
		    	    } else if(dist < _OuterRadius) {
						//輪っか
					}else if(dist < _OuterRadius + _OuterBlurThickness) {
						//aを調整
						texcol.w *= (1.0 - (dist - _OuterRadius) / _OuterBlurThickness);
		    	    } else {
						clip(-1.0);
					}		    	
		    	    return texcol;
			}

			ENDCG
		}
	}
}