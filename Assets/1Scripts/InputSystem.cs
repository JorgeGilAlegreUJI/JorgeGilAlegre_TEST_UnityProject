using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : SystemsBase
{
    private void Update()
    {
        TouchControl();
    }

    void TouchControl()
    {
        if(Input.touchCount <= 0)return;
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            Debug.Log(touch.position);
        }
    }
}
