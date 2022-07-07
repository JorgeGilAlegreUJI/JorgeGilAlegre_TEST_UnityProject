using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckBase : ObjectBase
{
    private void Awake()
    {
        StartCoroutine(StartDeath());
    }
}
