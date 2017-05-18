// Shader created with Shader Forge v1.34 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.34;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:32935,y:32754,varname:node_4795,prsc:2|emission-4052-OUT;n:type:ShaderForge.SFN_Tex2d,id:5624,x:32321,y:32658,ptovrint:False,ptlb:main text,ptin:_maintext,varname:node_5624,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-6557-OUT;n:type:ShaderForge.SFN_Tex2d,id:1759,x:31800,y:32852,ptovrint:False,ptlb:NOiSE,ptin:_NOiSE,varname:node_1759,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-2092-OUT;n:type:ShaderForge.SFN_Time,id:3044,x:31170,y:33005,varname:node_3044,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5865,x:31341,y:32952,varname:node_5865,prsc:2|A-651-OUT,B-3044-T;n:type:ShaderForge.SFN_Multiply,id:7950,x:31341,y:33083,varname:node_7950,prsc:2|A-3044-T,B-6750-OUT;n:type:ShaderForge.SFN_ValueProperty,id:651,x:31192,y:32925,ptovrint:False,ptlb:U,ptin:_U,varname:node_651,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:6750,x:31182,y:33161,ptovrint:False,ptlb:V,ptin:_V,varname:node_6750,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Append,id:7645,x:31490,y:32978,varname:node_7645,prsc:2|A-5865-OUT,B-7950-OUT;n:type:ShaderForge.SFN_Add,id:2092,x:31608,y:32791,varname:node_2092,prsc:2|A-9121-UVOUT,B-7645-OUT;n:type:ShaderForge.SFN_TexCoord,id:9121,x:31246,y:32724,varname:node_9121,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:1438,x:32128,y:32852,varname:node_1438,prsc:2|A-5584-OUT,B-7727-OUT,C-2922-OUT;n:type:ShaderForge.SFN_Add,id:6557,x:32143,y:32613,varname:node_6557,prsc:2|A-9121-UVOUT,B-1438-OUT,C-2092-OUT;n:type:ShaderForge.SFN_Multiply,id:5740,x:32523,y:32857,varname:node_5740,prsc:2|A-5624-RGB,B-2481-OUT,C-7970-RGB,D-440-RGB;n:type:ShaderForge.SFN_ToggleProperty,id:7727,x:31906,y:33015,ptovrint:False,ptlb:noise,ptin:_noise,varname:node_7727,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False;n:type:ShaderForge.SFN_VertexColor,id:440,x:32290,y:33108,varname:node_440,prsc:2;n:type:ShaderForge.SFN_Slider,id:2481,x:32068,y:33046,ptovrint:False,ptlb:liangdu,ptin:_liangdu,varname:node_2481,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:2;n:type:ShaderForge.SFN_ValueProperty,id:681,x:31754,y:33105,ptovrint:False,ptlb:noise size,ptin:_noisesize,varname:node_681,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Abs,id:2922,x:31922,y:33093,varname:node_2922,prsc:2|IN-681-OUT;n:type:ShaderForge.SFN_Color,id:7970,x:32253,y:32878,ptovrint:False,ptlb:main color,ptin:_maincolor,varname:node_7970,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Append,id:5584,x:31971,y:32852,varname:node_5584,prsc:2|A-1759-R,B-1759-R;n:type:ShaderForge.SFN_Multiply,id:3668,x:32598,y:33093,varname:node_3668,prsc:2|A-5624-A,B-440-A,C-7970-A;n:type:ShaderForge.SFN_Multiply,id:4052,x:32685,y:32873,varname:node_4052,prsc:2|A-5740-OUT,B-3668-OUT;proporder:5624-7970-1759-7727-681-651-6750-2481;pass:END;sub:END;*/

Shader "Custom/Rao_Liudong" {
    Properties {
        _maintext ("main text", 2D) = "white" {}
        _maincolor ("main color", Color) = (0.5,0.5,0.5,1)
        _NOiSE ("NOiSE", 2D) = "white" {}
        [MaterialToggle] _noise ("noise", Float ) = 0
        _noisesize ("noise size", Float ) = 0
        _U ("U", Float ) = 0
        _V ("V", Float ) = 0
        _liangdu ("liangdu", Range(0, 2)) = 1
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _maintext; uniform float4 _maintext_ST;
            uniform sampler2D _NOiSE; uniform float4 _NOiSE_ST;
            uniform float _U;
            uniform float _V;
            uniform fixed _noise;
            uniform float _liangdu;
            uniform float _noisesize;
            uniform float4 _maincolor;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 node_3044 = _Time + _TimeEditor;
                float2 node_2092 = (i.uv0+float2((_U*node_3044.g),(node_3044.g*_V)));
                float4 _NOiSE_var = tex2D(_NOiSE,TRANSFORM_TEX(node_2092, _NOiSE));
                float2 node_6557 = (i.uv0+(float2(_NOiSE_var.r,_NOiSE_var.r)*_noise*abs(_noisesize))+node_2092);
                float4 _maintext_var = tex2D(_maintext,TRANSFORM_TEX(node_6557, _maintext));
                float3 emissive = ((_maintext_var.rgb*_liangdu*_maincolor.rgb*i.vertexColor.rgb)*(_maintext_var.a*i.vertexColor.a*_maincolor.a));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
