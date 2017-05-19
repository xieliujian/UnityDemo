using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    #region 常量

    public const string INPUT_MOUSE_X = "Mouse X";
    public const string INPUT_MOUSE_Y = "Mouse Y";
    public const string ERROR_UNBindCam = "ThirdPersonCam脚本没有绑定摄像机!";

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
    /// 水平旋转的角度
    /// </summary>
    private float mAngleH = 0.0f;

    /// <summary>
    /// 垂直旋转的角度
    /// </summary>
    private float mAngleV = 0.0f;

    #endregion

    #region 内置函数

    void Awake()
    {
        mCamera = GetComponent<Camera>().transform;
    }

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    void LateUpdate()
    {
        if (mCamera == null)
            Debug.LogError(ERROR_UNBindCam);

        if (mPlayer != null)
        {
#if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                mAngleH += Mathf.Clamp(Input.GetAxis(INPUT_MOUSE_X), -1, 1) * mHorizontalAimingSpeed * Time.deltaTime;
                mAngleV += Mathf.Clamp(Input.GetAxis(INPUT_MOUSE_Y), -1, 1) * mVerticalAimingSpeed * Time.deltaTime;
            }
#endif

#if UNITY_ANDROID || UNITY_IOS

#endif

            mAngleV = Mathf.Clamp(mAngleV, mMinVerticalAngle, mMaxVerticalAngle);
        }

        Quaternion animRotation = Quaternion.Euler(-mAngleV, mAngleH, 0.0f);
        Quaternion camYRotation = Quaternion.Euler(0.0f, mAngleH, 0.0f);

        mCamera.rotation = animRotation;
        mCamera.position = mPlayer.position + camYRotation * mPivotOffset + animRotation * mCamOffset;
    }

    #endregion
}
