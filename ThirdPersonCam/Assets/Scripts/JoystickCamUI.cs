
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using HedgehogTeam.EasyTouch;

public class JoystickCamUI : MonoBehaviour
{
    #region 变量

    /// <summary>
    /// 窗口
    /// </summary>
    public UIWidget mWidget;

    /// <summary>
    /// 拖拽
    /// </summary>
    public Action<Vector2> OnDrag;

    /// <summary>
    /// 点击
    /// </summary>
    public Action OnClick;

    /// <summary>
    /// pinch事件
    /// </summary>
    public Action<float> OnPinch;

    /// <summary>
    /// 是否触发
    /// </summary>
    private bool mOnTouch = false;

    #endregion

    #region 内置函数

    // Use this for initialization
    void Start ()
    {
        UIEventListener.Get(mWidget.gameObject).onClick = OnWidgetClick;
        UIEventListener.Get(mWidget.gameObject).onDrag = OnWidgetDrag;
        UIEventListener.Get(mWidget.gameObject).onPress = OnWidgetPress;

        EasyTouch.On_Pinch += OnWidgetPinch;
    }
	
	// Update is called once per frame
	void Update ()
    {
       
    }

    void OnDestroy()
    {
        EasyTouch.On_Pinch -= OnWidgetPinch;
    }

    #endregion

    #region 回调函数

    private void OnWidgetClick(GameObject go)
    {
        if (OnClick != null)
            OnClick();
    }

    private void OnWidgetDrag(GameObject go, Vector2 delta)
    {
        if (!mOnTouch)
            return;

        if (OnDrag != null)
            OnDrag(delta);
    }

    private void OnWidgetPress(GameObject go, bool state)
    {
        mOnTouch = state;
    }

    private void OnWidgetPinch(Gesture gesture)
    {
        if (gesture.pickedObject != gameObject)
            return;

        float delta = gesture.deltaPinch * Time.deltaTime;

        mOnTouch = false;
        if (OnPinch != null)
            OnPinch(delta);
    }

    #endregion
}
