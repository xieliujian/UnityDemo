using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    #region 变量

    /// <summary>
    /// 摄像机
    /// </summary>
    private Camera mCamera;

    /// <summary>
    /// 玩家transform
    /// </summary>
    public Transform mPlayer;

    /// <summary>
    /// 水平瞄准速度
    /// </summary>
    public float mHorizontalAimingSpeed = 400.0f;

    /// <summary>
    /// 垂直瞄准速度
    /// </summary>
    public float mVerticalAimingSpeed = 400.0f;

    #endregion

    #region 内置函数

    void Awake()
    {
        mCamera = GetComponent<Camera>();
    }

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    void LateUpdate()
    {

    }

    #endregion
}
