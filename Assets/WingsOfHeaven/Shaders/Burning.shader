// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Wings/Burning"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_Color("Color", Color) = (0.8301887,0.8301887,0.8301887,1)
		_Albedo("Albedo", 2D) = "white" {}
		_MetallicSmoothness("MetallicSmoothness", 2D) = "white" {}
		_Metallic("Metallic", Float) = 1
		_Smoothness("Smoothness", Float) = 1
		_Normal("Normal", 2D) = "bump" {}
		_NormalStrength("NormalStrength", Float) = 1
		_EmissionMask("EmissionMask", 2D) = "black" {}
		[HDR]_EmissionColor("EmissionColor", Color) = (0,0,0,0)
		_BurningContrast("BurningContrast", Range( 0 , 1)) = 1
		_BurningMaskUV2("BurningMask(UV2)", 2D) = "white" {}
		_Speed("Speed", Float) = 1
		[HideInInspector] _texcoord2( "", 2D ) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "AlphaTest+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityStandardUtils.cginc"
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
			float2 uv2_texcoord2;
		};

		uniform float _NormalStrength;
		uniform sampler2D _Normal;
		uniform float4 _Normal_ST;
		uniform sampler2D _Albedo;
		uniform float4 _Albedo_ST;
		uniform float4 _Color;
		uniform float4 _EmissionColor;
		uniform float _BurningContrast;
		uniform sampler2D _BurningMaskUV2;
		uniform float4 _BurningMaskUV2_ST;
		uniform float _Speed;
		uniform sampler2D _EmissionMask;
		uniform float4 _EmissionMask_ST;
		uniform sampler2D _MetallicSmoothness;
		uniform float4 _MetallicSmoothness_ST;
		uniform float _Metallic;
		uniform float _Smoothness;
		uniform float _Cutoff = 0.5;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Normal = i.uv_texcoord * _Normal_ST.xy + _Normal_ST.zw;
			o.Normal = UnpackScaleNormal( tex2D( _Normal, uv_Normal ), _NormalStrength );
			float2 uv_Albedo = i.uv_texcoord * _Albedo_ST.xy + _Albedo_ST.zw;
			float4 tex2DNode5 = tex2D( _Albedo, uv_Albedo );
			o.Albedo = ( tex2DNode5 * _Color ).rgb;
			float2 uv1_BurningMaskUV2 = i.uv2_texcoord2 * _BurningMaskUV2_ST.xy + _BurningMaskUV2_ST.zw;
			float mulTime33 = _Time.y * 0.25;
			float cos25 = cos( ( _Speed * mulTime33 ) );
			float sin25 = sin( ( _Speed * mulTime33 ) );
			float2 rotator25 = mul( uv1_BurningMaskUV2 - float2( 1,0 ) , float2x2( cos25 , -sin25 , sin25 , cos25 )) + float2( 1,0 );
			float mulTime32 = _Time.y * -0.3;
			float cos26 = cos( ( _Speed * mulTime32 ) );
			float sin26 = sin( ( _Speed * mulTime32 ) );
			float2 rotator26 = mul( ( uv1_BurningMaskUV2 * float2( 0.25,0.5 ) ) - float2( -0.5,-1 ) , float2x2( cos26 , -sin26 , sin26 , cos26 )) + float2( -0.5,-1 );
			float smoothstepResult44 = smoothstep( ( 0.3 * _BurningContrast ) , ( 0.8 * _BurningContrast ) , ( tex2D( _BurningMaskUV2, rotator25 ).r - tex2D( _BurningMaskUV2, rotator26 ).r ));
			float2 uv0_EmissionMask = i.uv_texcoord * _EmissionMask_ST.xy + _EmissionMask_ST.zw;
			o.Emission = ( _EmissionColor * ( smoothstepResult44 * tex2D( _EmissionMask, uv0_EmissionMask ) ) ).rgb;
			float2 uv_MetallicSmoothness = i.uv_texcoord * _MetallicSmoothness_ST.xy + _MetallicSmoothness_ST.zw;
			float4 tex2DNode6 = tex2D( _MetallicSmoothness, uv_MetallicSmoothness );
			o.Metallic = ( tex2DNode6 * _Metallic ).r;
			o.Smoothness = ( tex2DNode6.a * _Smoothness );
			o.Alpha = 1;
			clip( ( tex2DNode5.a * _Color.a ) - _Cutoff );
		}

		ENDCG
	}
	Fallback "Diffuse"
}
/*ASEBEGIN
Version=17600
2000;39;1497;874;2161.796;103.0605;1;True;False
Node;AmplifyShaderEditor.RangedFloatNode;20;-2025.752,365.8616;Inherit;True;Property;_Speed;Speed;12;0;Create;True;0;0;False;0;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;33;-1848.527,236.799;Inherit;False;1;0;FLOAT;0.25;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;39;-1670.98,3.263931;Inherit;False;Constant;_Vector0;Vector 0;10;0;Create;True;0;0;False;0;0.25,0.5;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleTimeNode;32;-1762.898,541.3072;Inherit;False;1;0;FLOAT;-0.3;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;24;-1768.918,-197.5022;Inherit;False;1;27;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;30;-1548.349,415.3517;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.015;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;31;-1630.097,264.9755;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.25;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;40;-1424.803,80.28055;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RotatorNode;26;-1254.272,389.4614;Inherit;False;3;0;FLOAT2;0,0;False;1;FLOAT2;-0.5,-1;False;2;FLOAT;0.015;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TexturePropertyNode;27;-1010.258,459.398;Inherit;True;Property;_BurningMaskUV2;BurningMask(UV2);11;0;Create;True;0;0;False;0;None;None;False;white;Auto;Texture2D;-1;0;1;SAMPLER2D;0
Node;AmplifyShaderEditor.RotatorNode;25;-1134.479,110.1162;Inherit;False;3;0;FLOAT2;0,0;False;1;FLOAT2;1,0;False;2;FLOAT;0.25;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;45;-346.8994,245.4817;Inherit;False;Constant;_min;min;10;0;Create;True;0;0;False;0;0.3;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;43;-454.3822,495.4297;Inherit;False;Constant;_max;max;11;0;Create;True;0;0;False;0;0.8;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;28;-871.1278,208.3239;Inherit;True;Property;_TextureSample0;Texture Sample 0;3;0;Create;True;0;0;False;0;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;57;-525.8906,354.1968;Inherit;False;Property;_BurningContrast;BurningContrast;10;0;Create;True;0;0;False;0;1;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;16;-833.6023,0.3725545;Inherit;True;Property;_iinp;iinp;3;0;Create;True;0;0;False;0;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleSubtractOpNode;62;-464.0476,91.64008;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;55;-250.8906,450.1968;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;56;-151.5883,281.1038;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;63;-1354.518,-393.3407;Inherit;False;0;7;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;44;-92.17446,89.7806;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;7;-975.2002,-339.3257;Inherit;True;Property;_EmissionMask;EmissionMask;8;0;Create;True;0;0;False;0;-1;None;None;True;0;False;black;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;9;-260.3369,710.1817;Inherit;False;Property;_NormalStrength;NormalStrength;7;0;Create;True;0;0;False;0;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;15;500.1846,477.6867;Inherit;False;Property;_Smoothness;Smoothness;5;0;Create;True;0;0;False;0;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;29;39.79378,-73.3484;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;5;-579.7303,-813.1161;Inherit;True;Property;_Albedo;Albedo;2;0;Create;True;0;0;False;0;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;12;283.972,-21.68048;Inherit;False;Property;_Metallic;Metallic;4;0;Create;True;0;0;False;0;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;35;-23.29213,-319.4445;Inherit;False;Property;_EmissionColor;EmissionColor;9;1;[HDR];Create;True;0;0;False;0;0,0,0,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;6;-558.8402,-511.2623;Inherit;True;Property;_MetallicSmoothness;MetallicSmoothness;3;0;Create;True;0;0;False;0;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;51;-245.4099,-700.7838;Inherit;False;Property;_Color;Color;1;0;Create;True;0;0;False;0;0.8301887,0.8301887,0.8301887,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;8;-3.273407,687.345;Inherit;True;Property;_Normal;Normal;6;0;Create;True;0;0;False;0;-1;None;None;True;0;False;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;52;178.745,-835.8738;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;36;432.4705,-262.5162;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;13;532.8095,-0.2433853;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;54;219.4173,-559.8834;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;14;643.3078,241.5241;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;960.6349,-451.0823;Float;False;True;-1;2;;0;0;Standard;Wings/Burning;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Masked;0.5;True;True;0;False;TransparentCutout;;AlphaTest;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;30;0;20;0
WireConnection;30;1;32;0
WireConnection;31;0;20;0
WireConnection;31;1;33;0
WireConnection;40;0;24;0
WireConnection;40;1;39;0
WireConnection;26;0;40;0
WireConnection;26;2;30;0
WireConnection;25;0;24;0
WireConnection;25;2;31;0
WireConnection;28;0;27;0
WireConnection;28;1;26;0
WireConnection;16;0;27;0
WireConnection;16;1;25;0
WireConnection;62;0;16;1
WireConnection;62;1;28;1
WireConnection;55;0;43;0
WireConnection;55;1;57;0
WireConnection;56;0;45;0
WireConnection;56;1;57;0
WireConnection;44;0;62;0
WireConnection;44;1;56;0
WireConnection;44;2;55;0
WireConnection;7;1;63;0
WireConnection;29;0;44;0
WireConnection;29;1;7;0
WireConnection;8;5;9;0
WireConnection;52;0;5;0
WireConnection;52;1;51;0
WireConnection;36;0;35;0
WireConnection;36;1;29;0
WireConnection;13;0;6;0
WireConnection;13;1;12;0
WireConnection;54;0;5;4
WireConnection;54;1;51;4
WireConnection;14;0;6;4
WireConnection;14;1;15;0
WireConnection;0;0;52;0
WireConnection;0;1;8;0
WireConnection;0;2;36;0
WireConnection;0;3;13;0
WireConnection;0;4;14;0
WireConnection;0;10;54;0
ASEEND*/
//CHKSM=B6B37AA1886AD5E3EEAD074F41C6FDF54EF46291