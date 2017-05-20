using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public JoystickUI mJoystick;

    public Camera mCamera;

    public CharacterController mCharCtrl;

    Transform mTemp;

    #region 内置函数

    // Use this for initialization
	void Start () 
    {
        mJoystick.onMoveEnd = OnJoystickMoveEnd;

        GameObject go = new GameObject("TempJoystick");
        mTemp = go.transform;
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 dir = mJoystick.GetDir();
        if (dir != Vector3.zero)
        {
            OnJoystickMove(dir);
        }
    }

    #endregion

    private void OnJoystickMove(Vector3 dir)
    {
        Vector3 realdir = new Vector3(dir.x, 0.0f, dir.y);
        mTemp.eulerAngles = new Vector3(0.0f, mCamera.transform.eulerAngles.y, 0.0f);
        realdir = mTemp.TransformDirection(realdir);

        float angle = Vector3.Angle(transform.forward, realdir);
        realdir = Vector3.Slerp(transform.forward, realdir, Mathf.Clamp01(180 * Time.deltaTime * 5 / angle));
        transform.LookAt(transform.position + realdir);

        mCharCtrl.SimpleMove(realdir * 5);
    }

    private void OnJoystickMoveEnd(Vector2 delta)
    {
        
    }
}
