
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AnimClipExtractEditor : Editor
{
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
        string path = AssetDatabase.GetAssetPath(obj);

        int i = 0;
    }
}
