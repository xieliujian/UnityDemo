using UnityEngine;
using System.Collections;
using System;

public class InputManager : MonoBehaviour
{
    
    bool useTouch;
    bool useMouse;

    public static Action<Touch[]> touchesBegin;
    public static Action<Touch[]> touchesEnd;
    public static Action<Touch[]> touchesMove;
    public static Action<Touch[]> touchesStationary;
    public static Action<Touch[]> touchesTap;
    
    void Awake()
    {
        if ( Application.platform == RuntimePlatform.Android ||
             Application.platform == RuntimePlatform.IPhonePlayer)
        {
            useTouch = true;
            useMouse = false;
        }
        else
        {
            useMouse = true;
            useTouch = false;
        }
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (useTouch)
        {
            ProcessTouches();
        }      
    }

    void ProcessTouches()
    {
        if(Input.touchCount > 0)
        {
            foreach (Touch tc in Input.touches)
            {
                if(tc.phase == TouchPhase.Began && touchesBegin != null)
                {
                    touchesBegin(Input.touches);
                }
                else if (tc.phase == TouchPhase.Moved && touchesMove != null)
                {
                    touchesMove(Input.touches);
                }
                else if (tc.phase == TouchPhase.Stationary && touchesStationary != null)
                {
                    touchesStationary(Input.touches);
                }
                else if (tc.phase == TouchPhase.Ended && touchesEnd != null)
                {
                    touchesEnd(Input.touches);
                }
                else if (tc.phase == TouchPhase.Canceled && touchesEnd != null)
                {
                    touchesEnd(Input.touches);
                }
            }
        }
    }
}
