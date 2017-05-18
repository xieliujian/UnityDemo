// Shader created with Shader Forge v1.34 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.34;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:32759,y:32631,varname:node_4795,prsc:2|custl-9161-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:32248,y:32625,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Panner,id:7093,x:31766,y:32395,varname:node_7093,prsc:2,spu:0.01,spv:0.02|UVIN-6706-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:6706,x:31596,y:32395,varname:node_6706,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:6106,x:31944,y:32387,ptovrint:False,ptlb:liudong,ptin:_liudong,varname:node_6106,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:cac8992447ffd46478210ed7b60c979b,ntxv:0,isnm:False|UVIN-7093-UVOUT;n:type:ShaderForge.SFN_Add,id:9161,x:32549,y:32688,varname:node_9161,prsc:2|A-7519-OUT,B-6074-RGB;n:type:ShaderForge.SFN_Tex2d,id:4967,x:31934,y:32576,ptovrint:False,ptlb:mask,ptin:_mask,varname:node_4967,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1803d2889e3c2b64494da559f3f4a57f,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:5777,x:32169,y:32404,varname:node_5777,prsc:2|A-6106-RGB,B-4967-RGB,C-8581-RGB;n:type:ShaderForge.SFN_Color,id:8581,x:32024,y:32764,ptovrint:False,ptlb:mask color,ptin:_maskcolor,varname:node_8581,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:7519,x:32454,y:32409,varname:node_7519,prsc:2|A-5777-OUT,B-9392-OUT;n:type:ShaderForge.SFN_Slider,id:9392,x:32115,y:32528,ptovrint:False,ptlb:ld,ptin:_ld,varname:node_9392,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:3,max:3;proporder:6074-6106-4967-8581-9392;pass:END;sub:END;*/

Shader "Custom/fuhuoshixiang" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _liudong ("liudong", 2D) = "white" {}
        _mask ("mask", 2D) = "white" {}
        _maskcolor ("mask color", Color) = (0.5,0.5,0.5,1)
        _ld ("ld", Range(0, 3)) = 3
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _liudong; uniform float4 _liudong_ST;
            uniform sampler2D _mask; uniform float4 _mask_ST;
            uniform float4 _maskcolor;
            uniform float _ld;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
                float4 node_17 = _Time + _TimeEditor;
                float2 node_7093 = (i.uv0+node_17.g*float2(0.01,0.02));
                float4 _liudong_var = tex2D(_liudong,TRANSFORM_TEX(node_7093, _liudong));
                float4 _mask_var = tex2D(_mask,TRANSFORM_TEX(i.uv0, _mask));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 finalColor = (((_liudong_var.rgb*_mask_var.rgb*_maskcolor.rgb)*_ld)+_MainTex_var.rgb);
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
