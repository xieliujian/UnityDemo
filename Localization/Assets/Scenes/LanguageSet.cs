using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageSet : MonoBehaviour
{
    public UIToggle mEnglish;

    public UIToggle mFrançais;

    public UIToggle mChinese;

    #region 内置函数

    // Use this for initialization
    void Start ()
    {
        EventDelegate.Add(mEnglish.onChange, OnEnglishChange);
        EventDelegate.Add(mFrançais.onChange, OnFrançaisChange);
        EventDelegate.Add(mChinese.onChange, OnChineseChange);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    #endregion

    private void OnEnglishChange()
    {
        if (mEnglish.value)
        {
            Localization.language = mEnglish.name;
        }
    }

    private void OnFrançaisChange()
    {
        if (mFrançais.value)
        {
            Localization.language = mFrançais.name;
        }
    }

    private void OnChineseChange()
    {
        if (mChinese.value)
        {
            Localization.language = mChinese.name;
        }
    }
}
