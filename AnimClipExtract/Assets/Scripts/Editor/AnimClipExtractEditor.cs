
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class AnimClipExtractEditor : Editor
{
    private const string ANIM_PATH = "Assets/Art/3D/Characters/";
    private const string PREFABS_PATH = "Assets/Prefabs/3D/Characters/";
    private const string ANIMCLIP_PATH = "/AnimClips/";
    private const string FBX_SUFFIX = ".fbx";

    [MenuItem("Game/Anim/ExtractAll")]
    static void ExtractAll()
    {

    }

    [MenuItem("Game/Anim/ExtractOne")]
    static void ExtractOne()
    {
        if (Selection.objects.Length == 0)
            return;

        Object obj = Selection.objects[0];
        string name = obj.name;
        //string fullname = AssetDatabase.GetAssetPath(obj);
        GenerateAnim(name);
    }

    /// <summary>
    /// 生成一个动画资源
    /// </summary>
    /// <param name="name"></param>
    /// <param name="path"></param>
    private static void GenerateAnim(string fbxname)
    {
        string animclippath = PREFABS_PATH + fbxname + ANIMCLIP_PATH;
        SplitAnimClip(animclippath, fbxname);
    }

    private static void SplitAnimClip(string path, string fbxname)
    {
        string srcpath = ANIM_PATH + "/" + fbxname;

        var files = Directory.GetFiles(srcpath, "*.fbx");
        foreach (var file in files)
        {
            int i = 0;
        }
    }
}



