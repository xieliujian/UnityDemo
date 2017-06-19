
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputMgrName
{
    public const string Horizontal = "Horizontal";
    public const string Vertical = "Vertical";
}

public class JoystickUI : MonoBehaviour
{
    #region 变量

    /// <summary>
    /// 背景
    /// </summary>
    public UISprite mBg;

    /// <summary>
    /// touch
    /// </summary>
    public UISprite mTouch;

    /// <summary>
    /// 移动事件
    /// </summary>
    public Action<Vector2> OnMove;

    /// <summary>
    /// 移动结束事件
    /// </summary>
    public Action OnMoveEnd;

    /// <summary>
    /// 半径
    /// </summary>
    private float mRadius;
    
    /// <summary>
    /// 是否触摸
    /// </summary>
    private bool mOnTouch = false;

    #endregion

    #region 内置函数

    // Use this for initialization
    void Start ()
    {
        UIEventListener.Get(mTouch.gameObject).onPress = OnTouchPress;
        UIEventListener.Get(mTouch.gameObject).onDragStart = OnTouchDragStart;
        UIEventListener.Get(mTouch.gameObject).onDrag = OnTouchDrag;
        UIEventListener.Get(mTouch.gameObject).onDragEnd = OnTouchDragEnd;

        mRadius = mBg.width * 0.5f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        UpdateJoystick();
	}

    #endregion

    #region 回调函数

    private void OnTouchDragStart(GameObject go)
    {
        mOnTouch = true;
    }

    private void OnTouchDrag(GameObject go, Vector2 delta)
    {
        mOnTouch = true;
        mTouch.transform.localPosition += new Vector3(delta.x, delta.y, 0.0f);
        mTouch.transform.localPosition = Vector3.ClampMagnitude(mTouch.transform.localPosition, GetRadius());
    }

    private void OnTouchDragEnd(GameObject go)
    {
        mOnTouch = false;
        mTouch.transform.localPosition = Vector2.zero;
    }

    private void OnTouchPress(GameObject go, bool state)
    {
        mOnTouch = state;
        if (!state)
        {
            mTouch.transform.localPosition = Vector2.zero;
        }
    }

    #endregion

    #region 函数

    private void UpdateJoystick()
    {
        Transform touchtrans = mTouch.transform;
        if (!mOnTouch)
        {
            float x = Input.GetAxis(InputMgrName.Horizontal);
            float y = Input.GetAxis(InputMgrName.Vertical);

            touchtrans.localPosition = Vector2.zero;

            if (x != 0.0f)
            {
                touchtrans.localPosition = new Vector2(GetRadius() * x, touchtrans.localPosition.y);
            }

            if (y != 0.0f)
            {
                touchtrans.localPosition = new Vector2(touchtrans.localPosition.x, GetRadius() * y);
            }

            touchtrans.localPosition = Vector3.ClampMagnitude(touchtrans.localPosition, GetRadius());
        }

        Vector2 tempaxis = touchtrans.localPosition / GetRadius();
        if (tempaxis == Vector2.zero)
        {
            if (OnMoveEnd != null)
                OnMoveEnd();
        }
        else if (tempaxis.x != 0.0f || tempaxis.y != 0.0f)
        {
            if (OnMove != null)
                OnMove(tempaxis);
        }
    }

    private float GetRadius()
    {
        return mRadius;
    }

    #endregion
}
