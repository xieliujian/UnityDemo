using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIModelShow : MonoBehaviour
{
    public Transform mRole;

    public UIWidget mTouch;

    #region 内置函数

    // Use this for initialization
    void Start ()
    {
        UIEventListener.Get(mTouch.gameObject).onDrag = OnTouchDrag;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    #endregion

    #region 回调函数

    private void OnTouchDrag(GameObject go, Vector2 delta)
    {
        float yrot = mRole.localEulerAngles.y - (delta.x * 0.5f);
        mRole.localEulerAngles = new Vector3(mRole.localEulerAngles.x , yrot, mRole.localEulerAngles.z);
    }

    #endregion
}
