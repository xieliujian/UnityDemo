using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cn.sharesdk.unity3d;
using UnityEngine.UI;

public class TestQQAuthLogin : MonoBehaviour {

    #region 变量

    /// <summary>
    /// qq登录按钮
    /// </summary>
    public Button mQQLoginBtn;

    /// <summary>
    /// share sdk
    /// </summary>
    private ShareSDK mShareSDK;

    #endregion

    #region 内置函数

    void Awake()
    {
        
    }

    // Use this for initialization
    void Start ()
    {
        mShareSDK = ShareSDK.Instance;
        mShareSDK.authHandler = OnAuthHandler;
        mQQLoginBtn.onClick.AddListener(OnQQLoginBtnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    #endregion

    #region 回调函数

    private void OnQQLoginBtnClick()
    {
        Debug.Log("OnQQLoginBtnClick");

        if(mShareSDK.IsAuthorized(PlatformType.WeChat))
        {
            mShareSDK.CancelAuthorize(PlatformType.WeChat);
        }

        mShareSDK.Authorize(PlatformType.QQ);
    }

    private void OnAuthHandler(int reqID, ResponseState state, PlatformType type, Hashtable data)
    {
        Debug.Log("OnAuthHandler : reqID : " + reqID + " state : " + state + " type : " + type);
        Debug.Log("OnAuthHandler : data : " + data.toJson());

        if (state == ResponseState.Success)
        {
            if (type == PlatformType.QQ)
            {
                Hashtable datatemp = mShareSDK.GetAuthInfo(type);
                Debug.Log("QQData : " + datatemp.toJson());
            }
        }
    }

    #endregion
}
