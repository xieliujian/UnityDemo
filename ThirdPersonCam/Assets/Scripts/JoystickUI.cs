
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class JoystickUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Action<Vector3> onMove;
    public Action<Vector2> onMoveEnd;

    #region 变量

    public RectTransform mPosRect;

    public Image mTouch;

    private int mRadius;

    private bool mDrag = false;

    private Vector2 mBeginPos;

    #endregion

    #region 内置函数

    // Use this for initialization
	void Start () 
    {
        mRadius = (int)((mPosRect.rect.yMax - mPosRect.rect.yMin) / 2);
	}
	
	// Update is called once per frame
	void Update () {

    }

    #endregion

    #region 继承回调函数

    public void OnDrag(PointerEventData data)
    {
        if (mDrag)
        {
            Vector3 delta = data.position - mBeginPos;
            mTouch.transform.localPosition = Vector3.ClampMagnitude(delta, mRadius);
        }
    }

    public void OnBeginDrag(PointerEventData data)
    {
        mDrag = true;
        mBeginPos = data.position;
    }

    public void OnEndDrag(PointerEventData data)
    {
        mDrag = false;
        mTouch.transform.localPosition = Vector3.zero;
        onMoveEnd(Vector2.zero);
    }

    #endregion

    public Vector3 GetDir()
    {
        return mTouch.transform.localPosition.normalized;
    }
}
