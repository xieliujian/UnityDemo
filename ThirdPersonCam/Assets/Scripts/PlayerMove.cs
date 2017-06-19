using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public JoystickUI mJoystick;

    public Camera mCamera;

    public CharacterController mCharCtrl;

    private Animator mAnimator;

#if PLAYMOVEUSETEMPTRANS
    private Transform mTemp;
#endif

    #region 内置函数

    // Use this for initialization
	void Start () 
    {
        mJoystick.OnMove = OnJoystickMove;
        mJoystick.OnMoveEnd = OnJoystickMoveEnd;

#if PLAYMOVEUSETEMPTRANS
        GameObject go = new GameObject("TempJoystick");
        mTemp = go.transform;
#endif

        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () 
    {

    }

#endregion

    private void OnJoystickMove(Vector2 delta)
    {
        Vector3 realdir = new Vector3(delta.x, 0.0f, delta.y);

#if PLAYMOVEUSETEMPTRANS
        mTemp.eulerAngles = new Vector3(0.0f, mCamera.transform.eulerAngles.y, 0.0f);
        realdir = mTemp.TransformDirection(realdir);
#else
        realdir = Quaternion.AngleAxis(mCamera.transform.eulerAngles.y, Vector3.up) * realdir;
#endif

        float angle = Vector3.Angle(transform.forward, realdir);
        realdir = Vector3.Slerp(transform.forward, realdir, Mathf.Clamp01(180 * Time.deltaTime * 5 / angle));
        transform.LookAt(transform.position + realdir);

        mCharCtrl.SimpleMove(realdir * 5);
        mAnimator.SetBool("run", true);
    }

    private void OnJoystickMoveEnd()
    {
        mAnimator.SetBool("run", false);
    }
}
