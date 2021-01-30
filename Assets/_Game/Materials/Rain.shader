Shader "Custom/Rain"
{
    Properties
    {
	_RainTex ("Rain", 2D) = "white" {}
        _VignetteTex ("Vignette", 2D) = "white" {}
        _MainTex ("Texture", 2D) = "white" {}

    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }


            sampler2D _RainTex;
            sampler2D _VignetteTex;
            sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {
            	float2 motion = float2(_Time.x,_Time.y*2);
                fixed4 col = tex2D(_MainTex, i.uv);
	        fixed4 rain = tex2D(_RainTex, i.uv+motion);
	        fixed4 overlayTop = col*rain*2.0;
	        fixed4 overlayBot = 1.0-2.0*(1.0-col)*(1.0-rain);
	        fixed4 lerpVal = ceil((1.0-rain)*0.5);
	        fixed4 vignette = tex2D(_VignetteTex, i.uv);

                // just invert the colors
                //col.rgb = 1 - col.rgb;
                
                fixed4 suppousedlyOverlay =  lerp(col,rain,lerpVal);
                fixed4 ret = lerp(col,overlayTop,0.25)*(1-vignette.w*.75);
                ret = col*(1-vignette.w*.25);
                return ret;
            }
            ENDCG
        }
    }
}
