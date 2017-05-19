using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    #region 常量

    public const string INPUT_MOUSE_X = "Mouse X";
    public const string INPUT_MOUSE_Y = "Mouse Y";
    public const string INPUT_MOUSE_SCROLLWHEEL = "Mouse ScrollWheel";
    public const string ERROR_UN_BINDCAM = "ThirdPersonCam脚本没有绑定摄像机!";
    public const string ERROR_UN_PLAYER = "ThirdPersonCam脚本没有指定玩家";

    #endregion

    #region 变量

    /// <summary>
    /// 摄像机
    /// </summary>
    private Transform mCamera;

    /// <summary>
    /// 玩家transform
    /// </summary>
    public Transform mPlayer;

    /// <summary>
    /// 角色中心点偏移
    /// </summary>
    public Vector3 mPivotOffset = new Vector3(0.0f, 1.0f, 0.0f);

    /// <summary>
    /// 摄像机偏移
    /// </summary>
    public Vector3 mCamOffset = new Vector3(0.0f, 0.7f, -5.0f);

    /// <summary>
    /// 水平瞄准速度
    /// </summary>
    public float mHorizontalAimingSpeed = 400.0f;

    /// <summary>
    /// 垂直瞄准速度
    /// </summary>
    public float mVerticalAimingSpeed = 400.0f;

    /// <summary>
    /// 最大的垂直角度
    /// </summary>
    public float mMaxVerticalAngle = 30.0f;

    /// <summary>
    /// 最小的垂直角度
    /// </summary>
    public float mMinVerticalAngle = -60.0f;

    /// <summary>
    /// 基础摄像机偏移的倍率的最大值
    /// </summary>
    public float mMaxDistance = 3.0f;

    /// <summary>
    /// 基础摄像机偏移的倍率的最小值
    /// </summary>
    public float mMinDistance = 1.0f;

    /// <summary>
    /// 镜头推进的速度
    /// </summary>
    public float mZoomSpeed = 2.0f;

    /// <summary>
    /// 水平旋转的角度
    /// </summary>
    private float mAngleH = 0.0f;

    /// <summary>
    /// 垂直旋转的角度
    /// </summary>
    private float mAngleV = 0.0f;

    /// <summary>
    /// 基础摄像机偏移的倍率
    /// </summary>
    private float mDistance = 0.0f;

    private Vector2 mTouchMove = Vector2.zero;
    private Vector2 mTouchLastPos = Vector2.zero;

    #endregion

    #region 内置函数

    void Awake()
    {
        mCamera = GetComponent<Camera>().transform;
    }

    // Use this for initialization
	void Start ()
    {
        InputManager.touchesBegin += TouchesBegin;
        InputManager.touchesMove += TouchesMoved;
        InputManager.touchesEnd += TouchesEnd;
    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnDestroy()
    {
        InputManager.touchesBegin -= TouchesBegin;
        InputManager.touchesMove -= TouchesMoved;
        InputManager.touchesEnd -= TouchesEnd;
    }

    void LateUpdate()
    {
        if (mCamera == null)
        {
            Debug.LogError(ERROR_UN_BINDCAM);
            return;
        }

        if (mPlayer == null)
        {
            Debug.LogError(ERROR_UN_PLAYER);
            return;
        }

#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            mAngleH += Mathf.Clamp(Input.GetAxis(INPUT_MOUSE_X), -1.0f, 1.0f) * mHorizontalAimingSpeed * Time.deltaTime;
            mAngleV += Mathf.Clamp(Input.GetAxis(INPUT_MOUSE_Y), -1.0f, 1.0f) * mVerticalAimingSpeed * Time.deltaTime;
        }
#endif

#if UNITY_ANDROID || UNITY_IOS
        mAngleH += Mathf.Clamp(mTouchMove.x / Screen.width, -1.0f, 1.0f) * mHorizontalAimingSpeed * 2.0f;
        mAngleV += Mathf.Clamp(mTouchMove.y / Screen.height, -1.0f, 1.0f) * mVerticalAimingSpeed * 2.0f;
        mTouchMove = Vector2.zero;
#endif

        mAngleV = Mathf.Clamp(mAngleV, mMinVerticalAngle, mMaxVerticalAngle);

        Quaternion animRotation = Quaternion.Euler(-mAngleV, mAngleH, 0.0f);
        Quaternion camYRotation = Quaternion.Euler(0.0f, mAngleH, 0.0f);

        mDistance -= Input.GetAxis(INPUT_MOUSE_SCROLLWHEEL) * mZoomSpeed;
        mDistance = Mathf.Clamp(mDistance, mMinDistance, mMaxDistance);

        mCamera.rotation = animRotation;
        mCamera.position = mPlayer.position + camYRotation * mPivotOffset + animRotation * mCamOffset * mDistance;
    }

    #endregion

    #region 回调函数

    private void TouchesBegin(Touch[] touches)
    {
        foreach (var touch in touches)
        {
            if (touches.Length == 1)
            {
                mTouchLastPos = touch.position;
            }
            else if (touches.Length == 2)
            {

            }
        }
    }

    private void TouchesMoved(Touch[] touches)
    {
        foreach (var touch in touches)
        {
            if (touches.Length == 1)
            {
                mTouchMove = touch.position - mTouchLastPos;
                mTouchLastPos = touch.position;
            }
            else if (touches.Length == 2)
            {

            }
        }
    }

    private void TouchesEnd(Touch[] touches)
    {
        foreach (var touch in touches)
        {
            if (touches.Length == 1)
            {
                mTouchMove = Vector2.zero;
            }
            else if (touches.Length == 2)
            {

            }
        }
    }

    #endregion
}
