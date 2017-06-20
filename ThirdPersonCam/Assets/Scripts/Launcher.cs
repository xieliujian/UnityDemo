
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;

public class Launcher : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        //EasyTouch.instance.enabledNGuiMode = true;
        EasyTouch.Set3DPickableLayer(1 << LayerMask.NameToLayer("UI"));
        EasyTouch.AddCamera(UICamera.mainCamera, true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
