
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using cn.sharesdk.unity3d;

public class TestQQWeChatAuthLogin : MonoBehaviour
{
    #region 变量

    /// <summary>
    /// qq 认证按钮
    /// </summary>
    public Button mQQAuthBtn;

    /// <summary>
    /// wechat 认证按钮
    /// </summary>
    public Button mWeChatAuthBtn;

    /// <summary>
    /// share sdk
    /// </summary>
    private ShareSDK mShareSDK;

    #endregion

    #region 内置函数

    private void Awake()
    {
        mShareSDK = ShareSDK.Instance;
    }

    // Use this for initialization
    void Start ()
    {
        mShareSDK.authHandler = OnAuthHandler;
        mQQAuthBtn.onClick.AddListener(OnQQAuthBtnClick);
        mWeChatAuthBtn.onClick.AddListener(OnWeChatAuthBtnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    #endregion

    #region 回调函数

    private void OnQQAuthBtnClick()
    {
        Debug.Log("OnQQAuthBtnClick");

        if (mShareSDK.IsAuthorized(PlatformType.WeChat))
            mShareSDK.CancelAuthorize(PlatformType.WeChat);

        mShareSDK.Authorize(PlatformType.QQ);
    }

    private void OnWeChatAuthBtnClick()
    {
        Debug.Log("OnWeChatAuthBtnClick");

        if (mShareSDK.IsAuthorized(PlatformType.QQ))
            mShareSDK.CancelAuthorize(PlatformType.QQ);

        mShareSDK.Authorize(PlatformType.WeChat);
    }

    private void OnAuthHandler(int reqID, ResponseState state, PlatformType type, Hashtable data)
    {
        Debug.Log("OnAuthHandler state : " + state);
        Debug.Log("OnAuthHandler reqID : " + reqID + " type : " + type);
        Debug.Log("OnAuthHandler data : " + data.toJson());

        if (state == ResponseState.Success)
        {
            if (type == PlatformType.QQ)
            {
                Hashtable datatemp = mShareSDK.GetAuthInfo(type);
                string qqdata = datatemp.toJson();
                Debug.Log("OnAuthHandler qqdata : " + qqdata);
            }
            else if (type == PlatformType.WeChat)
            {
                Hashtable datatemp = mShareSDK.GetAuthInfo(type);
                string wechatdata = datatemp.toJson();
                Debug.Log("OnAuthHandler wechatdata : " + wechatdata);
            }
        }
    }

    #endregion
}
