Shader "Custome/My Additive"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags{ Queue = Transparent }
		Blend One One
		ZWrite Off

		Pass
		{
			SetTexture[_MainTex]
		}
	}
}
