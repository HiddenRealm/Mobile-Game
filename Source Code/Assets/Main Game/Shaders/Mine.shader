// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

shader "Custome/Glow"{
	//Variables
	Properties{
		//Sends in an Image
		_MainTexture("Main Colour (RGB)", 2D) = "white" {}
		//Sends in a Colour
		_Color("Colour", Color) = (1,1,1,1)
	}

		//Think its like a class
	SubShader{
		//Does a majority of the things, bad to have too many	
		Pass{
			//Opening Nvidia CG
			CGPROGRAM

			//includes?
			#pragma vertex vfunctionName
			#pragma fragment ffunctionName

			#include "UnityCG.cginc"

			//Input Data - Vertices/Normal/Colour/UV's
			struct appdata{
				//Float4 (1,1,1,1) - Float2 (1,1)
				//position (x,y,z,w) - Tex (x,y)
				float4 vertex : POSITION;
				float2 uv :TEXCOORD0;
			};
			
			struct v2f{
				float4 position : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			float4 _Color;
			sampler2D _MainTexture;
			
			//Vertex Function - Builds the Objects
			v2f vfunctionName(appdata IN){
				v2f OUT;

				OUT.position = UnityObjectToClipPos(IN.vertex);
				OUT.uv = IN.uv;

				return OUT;
			}

			//Fragment Function - Colours or Tectures the Objects
			fixed4 ffunctionName(v2f IN) : SV_Target{
				float4 textureColor = tex2D(_MainTexture, IN.uv);


				return textureColor * _Color;
			}

			//Closing Nvidia CG
			ENDCG
		}
	}
}