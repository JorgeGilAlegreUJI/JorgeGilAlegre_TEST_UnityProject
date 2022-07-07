using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Touch = UnityEngine.Touch;

public class InputSystem : SystemsBase
{
    private Vector2 firstInput = Vector2.zero;
    private Vector2 inputDir;

    private void Update()
    {
        TouchControl();
    }

    void TouchControl()
    {
        if (!ActiveInput)
        {
            if (firstInput != Vector2.zero)
            {
                InputAction();
            }
            firstInput = Vector2.zero;
            return;
        }

        Vector2 touchPos = GetTouchScreenPos();
        if (firstInput == Vector2.zero) firstInput = touchPos;

        inputDir = touchPos - firstInput;

    }

    void InputAction()
    {
        SystemsHub.puckSpawner.LaunchNewPuck(SystemsHub.puckSpawner.woodPuckPrefab,inputDir);
    }

    bool ActiveInput
    {
        get
        {
            if (Application.isEditor) return Input.GetMouseButton(0);
            else return false;
        }
    }
    Vector2 GetTouchScreenPos()
    {
        if (Application.isEditor) return Input.mousePosition;

        return Vector2.one * -1f;
    }
}
