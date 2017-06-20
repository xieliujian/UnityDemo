
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThirdPersonCam : MonoBehaviour
{
    #region 常量

#if USEINPUTSYSTEM
    public const string INPUT_MOUSE_X = "Mouse X";
    public const string INPUT_MOUSE_Y = "Mouse Y";
#endif
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
    public float mMaxDistance = 2.0f;

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

#if USEINPUTSYSTEM
    private Vector2 mTouchMove = Vector2.zero;

    private Vector2 mTouchLastPos = Vector2.zero;
#else
    /// <summary>
    /// 控制摄像机的ui
    /// </summary>
    public JoystickCamUI mJoystickCamUI;
#endif

    #endregion

    #region 内置函数

    void Awake()
    {
        mCamera = GetComponent<Camera>().transform;
        mDistance = (mMinDistance + mMaxDistance) * 0.5f;
    }

    // Use this for initialization
	void Start ()
    {
#if USEINPUTSYSTEM
        InputManager.touchesBegin += TouchesBegin;
        InputManager.touchesMove += TouchesMoved;
        InputManager.touchesStationary += TouchesStationary;
        InputManager.touchesEnd += TouchesEnd;
#else
        mJoystickCamUI.OnDrag += OnJoystickCamDrag;
        mJoystickCamUI.OnPinch += OnJoystickCamPinch;
#endif
    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnDestroy()
    {
#if USEINPUTSYSTEM
        InputManager.touchesBegin -= TouchesBegin;
        InputManager.touchesMove -= TouchesMoved;
        InputManager.touchesStationary -= TouchesStationary;
        InputManager.touchesEnd -= TouchesEnd;
#else
        mJoystickCamUI.OnDrag -= OnJoystickCamDrag;
        mJoystickCamUI.OnPinch -= OnJoystickCamPinch;
#endif
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

#if USEINPUTSYSTEM

#if UNITY_EDITOR
        if (Input.GetMouseButton(1))
        {
            mAngleH += Mathf.Clamp(Input.GetAxis(INPUT_MOUSE_X), -1.0f, 1.0f) * mHorizontalAimingSpeed * Time.deltaTime;
            mAngleV += Mathf.Clamp(Input.GetAxis(INPUT_MOUSE_Y), -1.0f, 1.0f) * mVerticalAimingSpeed * Time.deltaTime;
        }
#endif

#if UNITY_ANDROID || UNITY_IOS
        mAngleH += Mathf.Clamp(mTouchMove.x / Screen.width, -1.0f, 1.0f) * mHorizontalAimingSpeed * 2.0f;
        mAngleV += Mathf.Clamp(mTouchMove.y / Screen.height, -1.0f, 1.0f) * mVerticalAimingSpeed * 2.0f;
#endif

        mDistance -= Input.GetAxis(INPUT_MOUSE_SCROLLWHEEL) * mZoomSpeed;
#endif

        mAngleV = Mathf.Clamp(mAngleV, mMinVerticalAngle, mMaxVerticalAngle);

        Quaternion animRotation = Quaternion.Euler(-mAngleV, mAngleH, 0.0f);
        Quaternion camYRotation = Quaternion.Euler(0.0f, mAngleH, 0.0f);
        mDistance = Mathf.Clamp(mDistance, mMinDistance, mMaxDistance);

        mCamera.rotation = animRotation;
        mCamera.position = mPlayer.position + camYRotation * mPivotOffset + animRotation * mCamOffset * mDistance;
    }

#endregion

    #region 回调函数

#if USEINPUTSYSTEM
    private int mJoystickIndex = -1;

    private int mMoveIndex = -1;

    private void TouchesBegin(Touch[] touches)
    {
        for (int i = 0; i < touches.Length; i++)
        {
            Touch touch = touches[i];

            if (mJoystickIndex == -1)
            {
                if (IsTouchOnJoystick(touch.position))
                {
                    mJoystickIndex = i;
                }
            }

            if (mJoystickIndex == -1 && touches.Length == 1)
            {
                mMoveIndex = i;
                mTouchMove = Vector2.zero;
                mTouchLastPos = touch.position;
            }
            else if ((mJoystickIndex != -1) && (i != mJoystickIndex) && (i < 2))
            {
                mMoveIndex = i;
                mTouchMove = Vector2.zero;
                mTouchLastPos = touch.position;
            }
        }
    }

    private void TouchesMoved(Touch[] touches)
    {
        for (int i = 0; i < touches.Length; i++)
        {
            Touch touch = touches[i];

            if (i == mMoveIndex)
            {
                mTouchMove = touch.position - mTouchLastPos;
                mTouchLastPos = touch.position;
            }
        }
    }

    private void TouchesStationary(Touch[] touches)
    {
        for (int i = 0; i < touches.Length; i++)
        {
            Touch touch = touches[i];

            if (i == mMoveIndex)
            {
                mTouchMove = Vector2.zero;
            }
        }
    }

    private void TouchesEnd(Touch[] touches)
    {
        for (int i = 0; i < touches.Length; i++)
        {
            Touch touch = touches[i];

            if (i == mJoystickIndex)
            {
                mJoystickIndex = -1;
            }
            else if (i == mMoveIndex)
            {
                mMoveIndex = -1;
                mTouchMove = Vector2.zero;
            }
        }
    }
#else
    private void OnJoystickCamDrag(Vector2 delta)
    {
        mAngleH += Mathf.Clamp(delta.x / Screen.width, -1.0f, 1.0f) * mHorizontalAimingSpeed;
        mAngleV += Mathf.Clamp(delta.y / Screen.height, -1.0f, 1.0f) * mVerticalAimingSpeed;
    }

    private void OnJoystickCamPinch(float delta)
    {
        mDistance += delta * mZoomSpeed;
    }
#endif

    #endregion

    #region 函数

#if USEINPUTSYSTEM
    private bool IsTouchOnJoystick(Vector2 touchpos)
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return true;

        Rect rect = new Rect(0, 0, Screen.width / 3.0f, Screen.height / 2.0f);
        return rect.Contains(touchpos);
    }
#endif

    #endregion
}
