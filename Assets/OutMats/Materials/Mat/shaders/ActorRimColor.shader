Shader "Unlit/ActorRimColor"
{
	//属性
	Properties{
		_MainTex("Base (RGB), Alpha (A)", 2D) = "black" {}
		_GlowColor("RimColor", Color) = (1,1,0,1)
		_GlowPower("RimPower", Range(0.000001, 10.0)) = 1
	}
 
	//子着色器	
	SubShader
	{
				//定义Tags
			Tags{ 
			"Queue" = "Transparent+10"
			"RenderType" = "Transparent"
			}

		Pass
		{

			Blend SrcAlpha OneMinusSrcAlpha
 			//Blend One One
			Cull Back Lighting Off
			//ZTest GEqual 

			CGPROGRAM
			//引入头文件
			fixed4 _GlowColor;
			float _GlowPower;

			sampler2D _MainTex;
			float4 _MainTex_ST;
 
 			struct appdata_base {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float2 texcoord : TEXCOORD0;
			};

			//定义结构体：vertex shader阶段输出的内容
			struct v2f
			{
				float4 pos : SV_POSITION;
				half2 texcoord : TEXCOORD0;
				float3 worldNormal : TEXCOORD1;
				//在vertex shader中计算观察方向传递给fragment shader
				float3 worldViewDir : TEXCOORD2;
			};
 
			//定义顶点shader,参数直接使用appdata_base（包含position, noramal, texcoord）
			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.texcoord = v.texcoord;
				o.worldNormal = mul(v.normal, (float3x3)unity_WorldToObject);
				//顶点转化到世界空间
				float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				//可以把计算计算ViewDir的操作放在vertex shader阶段，毕竟逐顶点计算比较省
				o.worldViewDir = _WorldSpaceCameraPos.xyz - worldPos;
				return o;
			}
 
			//定义片元shader
			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.texcoord);

				//归一化法线，即使在vert归一化也不行，从vert到frag阶段有差值处理，传入的法线方向并不是vertex shader直接传出的
				fixed3 worldNormal = normalize(i.worldNormal);
				//把光照方向归一化
				fixed3 worldLightDir = normalize(_WorldSpaceLightPos0.xyz);
				
				//把视线方向归一化
				float3 worldViewDir = normalize(i.worldViewDir);
				//计算视线方向与法线方向的夹角，夹角越大，dot值越接近0，说明视线方向越偏离该点，也就是平视，该点越接近边缘
				float rim = 1 - max(0, dot(worldViewDir, worldNormal));
				//计算rimLight
				fixed4 rimColor = _GlowColor * pow(rim, 1 / _GlowPower);

				//rimColor.a = _GlowColor.a/4;
				//fixed4 color = rimColor;
				
				return col + rimColor;
			}
 
			//使用vert函数和frag函数
			#pragma vertex vert
			#pragma fragment frag	
 
			ENDCG
		}
	}
	//前面的Shader失效的话，使用默认的Diffuse
	FallBack "Diffuse"
}
