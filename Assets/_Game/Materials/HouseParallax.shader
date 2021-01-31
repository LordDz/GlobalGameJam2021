Shader "Unlit/HouseParallax"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _HouseNear ("Texture", 2D) = "white" {}        
        _HouseMid ("Texture", 2D) = "white" {}
        _HouseFar ("Texture", 2D) = "white" {}
        _Sky ("Texture", 2D) = "white" {}
	_Track ("Texture", 2D) = "white" {}
	_Foreground ("Texture", 2D) = "white" {}

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;          
            float4 _MainTex_ST;
            sampler2D _HouseNear;            
            sampler2D _HouseMid;
            sampler2D _HouseFar;
            sampler2D _Sky;
            sampler2D _Track;
            sampler2D _Foreground;
                        
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                float t = -_Time.y;
                float2 sfg = float2(t*4,0);
                float2 s0 = float2(t*2,0);                
                float2 s1 = float2(t,0);
                float2 s2 = float2(t*.75,0);
                float2 s3 = float2(t*.5,sin(t*0.25)/3.14*.1-.2);
                float2 s4 = float2(t*.1,0);
                fixed4 main = tex2D(_MainTex, i.uv);
                fixed4 fg = tex2D(_Foreground, i.uv+sfg+float2(0,0.06)+sin(t*1)/3.14*.125);
                fixed4 h0 = tex2D(_Track, i.uv+s0+float2(0,0.03));
                fixed4 h1 = tex2D(_HouseNear, i.uv+s1);
                float h2a=.75;
                float h3a=.5;
                float4 bgcol = float4(0,0,1,1);
                fixed4 h2 = tex2D(_HouseMid, i.uv+s2)*fixed4(h2a,h2a,h2a,1);
                h2 = lerp(h2,h2*bgcol,fixed4(1-h2a,1-h2a,1-h2a,0));
                fixed4 h3 = tex2D(_HouseFar, i.uv+s3)*fixed4(h3a,h3a,h3a,1);
                h3 = lerp(h3,h3*bgcol,fixed4(1-h3a,1-h3a,1-h3a,0));
                fixed4 sky = tex2D(_Sky, i.uv+s4);
                
                fixed4 blendfg = lerp(h0,fg,fg.a);
		fixed4 blend0 = lerp(h1,blendfg,blendfg.a);
		//fixed4 blend1 = lerp(h2,h1,h1.a);                              
                fixed4 blend1 = lerp(h2,blend0,blend0.a);
                fixed4 blend2 = lerp(h3,blend1,blend1.a);
                fixed4 blend3 = lerp(sky,blend2,blend2.a);
                
                fixed4 lightingIsh=fixed4(.4,.66,.89,1.0);
                
                fixed4 ret = blend3*lightingIsh;
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, ret);
                return ret;
            }
            ENDCG
        }
    }
}
